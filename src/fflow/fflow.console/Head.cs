using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using CLAP;
using fflow.body;
using fflow.body.providers;
using fflow.console.providers;

namespace fflow.console
{
	public class Head {
		SessionRepository sessionrepo;
		Body body;

		public Head(SessionRepository sessionrepo, Body body) {
			this.body = body;
			this.sessionrepo = sessionrepo;
		}


		[Verb]
		public void Stations(
			[Aliases("p,path,w,wf,workflow"), Required] string workflowpath
		){
			// open workflow: show stations
			// open workflow station: show files in inbox and wip
			throw new NotImplementedException ("Open hasn't been implemented yet.");
		}

		[Verb]
		public void Documents(
			[Aliases("p,path,w,wf,workflow"), Required] string workflowpath,
			[Aliases("s,station,step")] string stationname
		){
			// open workflow: show stations
			// open workflow station: show files in inbox and wip
			throw new NotImplementedException ("Open hasn't been implemented yet.");
		}


		[Verb]
		public void Edit(
			[Aliases("p,path,w,wf,workflow")] string workflowpath,
			[Aliases("s,station,step")] string stationname,
			[Aliases("d,doc,docname,f,file,filename"),Required] string documentfilename
		){
			var session = this.sessionrepo.Update (workflowpath, stationname);
			var docinfo = this.body.Edit (session.WorkflowPath, session.Stationname, documentfilename);
			Display_documentinfo (docinfo);
		}

	
		[Verb]
		public void Push(
			[Aliases("p,path,w,wf,workflow")] string workflowpath,
			[Aliases("s,station,step")] string stationname,
			[Aliases("d,doc,docname,f,file,filename"),Required] string documentfilename,
			[Aliases("a,act"),Required] string actionname
		){
			var session = this.sessionrepo.Update (workflowpath, stationname);
			var docinfo = this.body.Push (session.WorkflowPath, session.Stationname, documentfilename, actionname);
			Display_documentinfo (docinfo);
		}


		private void Display_documentinfo(DocumentInfo docinfo) {
			Console.WriteLine ("Document: {0}", docinfo.Documentpath);
			foreach (var logline in docinfo.Loglines)
				Console.WriteLine ("  {0}", logline);
		}
	}
}