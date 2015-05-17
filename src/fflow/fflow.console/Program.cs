using System;
using System.IO;
using CLAP;
using fflow.body;
using fflow.body.providers;
using fflow.console.providers;


namespace fflow.console
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var session = new SessionRepository ();
			var wfprov = new WorkflowProvider ();
			var proc = new ProcessProvider ();
			var configrepo = new WorkflowConfigRepository ();
			var exec = new Executor (wfprov);
			var body = new Body (wfprov, proc, configrepo, exec);
			var head = new Head (session, body);
			Parser.Run<Head> (args, head);
		}
	}
}