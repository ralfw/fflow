using System;
using System.Linq;
using System.Diagnostics;
using CLAP;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace fflow.console
{
	public class Head {
		Session session;
		FilesystemProvider filesys;
		ProcessProvider process;

		public Head(Session session, FilesystemProvider filesys, ProcessProvider process) {
			this.process = process;
			this.filesys = filesys;
			this.session = session;
		}


		[Verb]
		public void Edit(
			[Aliases("p,path,w,wf,workflow")] string workflowpath,
			[Aliases("s,station,step")] string stationname,
			[Aliases("d,doc,docname,f,file,filename"),Required] string documentfilename
		){
			workflowpath = this.session.Switch_to_workflow (workflowpath);
			stationname = this.session.Switch_to_station (stationname);

			var documentpath = this.filesys.Locate_document (workflowpath, stationname, documentfilename);
			documentpath = this.filesys.Pull_document (documentpath);

			this.process.Open_document (documentpath);
		}

	
		[Verb]
		public void Push(
			[Aliases("p,path,w,wf,workflow")] string workflowpath,
			[Aliases("s,station,step")] string stationname,
			[Aliases("d,doc,docname,f,file,filename"),Required] string documentfilename,
			[Aliases("a,act"),Required] string actionname
		){
			workflowpath = this.session.Switch_to_workflow (workflowpath);
			stationname = this.session.Switch_to_station (stationname);

			var documentpath = this.filesys.Locate_document (workflowpath, stationname, documentfilename);

			var stationpath = this.filesys.Locate_station (workflowpath, stationname);
			var config = Load_workflow_config (stationpath);

			Execute_action (workflowpath, documentpath, actionname, config.Actions);
		}


		public WorkflowConfig Load_workflow_config(string stationpath) {
			var flowconfigpath = Path.Combine (stationpath, ".fflow.json");
			if (!File.Exists (flowconfigpath)) return new WorkflowConfig ();

			var flowconfigjson = File.ReadAllText (flowconfigpath);
			return JsonConvert.DeserializeObject<WorkflowConfig> (flowconfigjson);
		}


		public void Execute_action(string workflowpath, string documentpath, string selectedActionname, IEnumerable<WorkflowAction> actions) {
			var action = actions.First (a => a.Name == selectedActionname);

			if (action.Command.StartsWith ("@")) {
				switch (action.Command) {
				case "@push":
					Push_document (documentpath, workflowpath, action.Args);
					break;
				default:
					throw new ArgumentException ("Unkown build-in action: " + selectedActionname);
				}
			} else
				throw new NotImplementedException ("Custom action handling not implemented yet!");
		}


		public void Push_document(string documentpath, string workflowpath, string stationname) {
			var stationpath = this.filesys.Locate_station(workflowpath, stationname);

			var newDocumentpath = Path.Combine (stationpath, Path.GetFileName (documentpath));
			File.Move (documentpath, newDocumentpath);

			var newDocumentlogpath = newDocumentpath + ".log";
			File.Move (documentpath + ".log", newDocumentlogpath);

			Logger.Current.Write (newDocumentpath, "pushed", stationname);
		}
	}
}