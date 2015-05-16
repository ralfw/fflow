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
		SessionRepository sessionrepo;
		WorkflowProvider wfprov;
		ProcessProvider process;
		WorkflowConfigRepository configrepo;
		Executor exec;

		public Head(SessionRepository sessionrepo, WorkflowProvider wfprov, 
					ProcessProvider process, WorkflowConfigRepository configrepo,
			Executor exec) {
			this.exec = exec;
			this.configrepo = configrepo;
			this.process = process;
			this.wfprov = wfprov;
			this.sessionrepo = sessionrepo;
		}


		[Verb]
		public void Edit(
			[Aliases("p,path,w,wf,workflow")] string workflowpath,
			[Aliases("s,station,step")] string stationname,
			[Aliases("d,doc,docname,f,file,filename"),Required] string documentfilename
		){
			var session = this.sessionrepo.Update (workflowpath, stationname);

			var documentpath = this.wfprov.Locate_document (session.WorkflowPath, session.Stationname, documentfilename);
			documentpath = this.wfprov.Pull_document (documentpath);

			this.process.Open_document (documentpath);
		}

	
		[Verb]
		public void Push(
			[Aliases("p,path,w,wf,workflow")] string workflowpath,
			[Aliases("s,station,step")] string stationname,
			[Aliases("d,doc,docname,f,file,filename"),Required] string documentfilename,
			[Aliases("a,act"),Required] string actionname
		){
			var session = this.sessionrepo.Update (workflowpath, stationname);

			var documentpath = this.wfprov.Locate_document (session.WorkflowPath, session.Stationname, documentfilename);

			var stationpath = this.wfprov.Locate_station (session.WorkflowPath, session.Stationname);
			var config = this.configrepo.Load_workflow_config (stationpath);

			this.exec.Run (session.WorkflowPath, documentpath, actionname, config.Actions);
		}
	}
}