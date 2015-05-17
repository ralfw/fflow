using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using CLAP;
using fflow.body;
using fflow.body.data;
using fflow.body.providers;
using fflow.console.providers;

namespace fflow.console
{
	public class Head {
		SessionRepository sessionrepo;
		Body body;
		ConsoleProvider console;

		public Head(SessionRepository sessionrepo, ConsoleProvider console, Body body) {
			this.console = console;
			this.body = body;
			this.sessionrepo = sessionrepo;
		}


		[Verb]
		public void Stations(
			[Aliases("p,path,w,wf,workflow"), Required] string workflowpath
		){
			var session = this.sessionrepo.Update (workflowpath);
			var stationinfos = this.body.Get_stations (session.WorkflowPath);
			this.console.Display (workflowpath, stationinfos);
		}

		[Verb]
		public void Documents(
			[Aliases("p,path,w,wf,workflow")] string workflowpath,
			[Aliases("s,station,step")] string stationname
		){
			var session = this.sessionrepo.Update (workflowpath, stationname);
			var stationdetails = this.body.Get_station_documents (session.WorkflowPath, session.Stationname);
			this.console.Display (workflowpath, stationdetails);
		}


		[Verb]
		public void Edit(
			[Aliases("p,path,w,wf,workflow")] string workflowpath,
			[Aliases("s,station,step")] string stationname,
			[Aliases("d,doc,docname,f,file,filename"),Required] string documentfilename
		){
			var session = this.sessionrepo.Update (workflowpath, stationname);
			var docinfo = this.body.Edit (session.WorkflowPath, session.Stationname, documentfilename);
			this.console.Display (docinfo);
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
			this.console.Display (docinfo);
		}
	}
}