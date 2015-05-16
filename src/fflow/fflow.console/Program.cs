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
		public void Open(
			[Aliases("p,path,w,wf,workflow,n,name"),Required] string workflowpath
		) {
			Console.WriteLine ("Opened workflow: {0}", workflowpath);
		}

		[Verb]
		public void Enter(
			[Aliases("s,station,step,n,name"),Required] string stationname
		) {
			
		}

		[Verb,Aliases("Get,Start,Begin")]
		public void Pull(
			[Aliases("d,doc,docname,f,filename,n,name"),Required] string documentfilename
		){
			
		}

		[Verb]
		public void Edit(
			[Aliases("d,doc,docname,f,filename,n,name"),Required] string documentfilename
		){
			
		}

		[Verb,Aliases("End,Finish")]
		public void Push(
			[Aliases("d,doc,docname,f,filename,n,name"),Required] string documentfilename,
			[Aliases("a,act"),Required] string action
		){
			
		}

	}
}