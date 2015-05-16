using System;
using CLAP;

namespace fflow.console
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var head = new Head ();
			Parser.Run<Head> (args, head);
		}
	}



	public class Head {
		[Verb]
		public void Edit(
			[Aliases("p,path,w,wf,workflow"),Required] string workflowpath,
			[Aliases("s,station,step"),Required] string stationname,
			[Aliases("d,doc,docname,f,file,filename"),Required] string documentfilename
		){
			Console.WriteLine ("edit: {0},{1},{2}", workflowpath,stationname,documentfilename);
		}


		[Verb]
		public void Push(
			[Aliases("p,path,w,wf,workflow"),Required] string workflowpath,
			[Aliases("s,station,step"),Required] string stationname,
			[Aliases("d,doc,docname,f,file,filename"),Required] string documentfilename,
			[Aliases("a,act"),Required] string action
		){
			Console.WriteLine ("push: {0},{1},{2},{3}", workflowpath,stationname,documentfilename,action);	
		}
	}
}