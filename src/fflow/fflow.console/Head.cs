using System;
using CLAP;
using System.IO;

namespace fflow.console
{
		
	public class Head {
		Session session;

		public Head(Session session) {
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

			Console.WriteLine ("edit: {0},{1},{2}", workflowpath,stationname,documentfilename);
		}


		[Verb]
		public void Push(
			[Aliases("p,path,w,wf,workflow")] string workflowpath,
			[Aliases("s,station,step")] string stationname,
			[Aliases("d,doc,docname,f,file,filename"),Required] string documentfilename,
			[Aliases("a,act"),Required] string action
		){
			workflowpath = this.session.Switch_to_workflow (workflowpath);
			stationname = this.session.Switch_to_station (stationname);

			Console.WriteLine ("push: {0},{1},{2},{3}", workflowpath,stationname,documentfilename,action);	
		}
	}
}