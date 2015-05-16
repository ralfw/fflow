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
			[Aliases("p,path,w,wf,workflow")] string workflowpath) {
			Console.WriteLine ("Opened workflow: {0}", workflowpath);
		}
	}
}