using System;
using System.IO;
using CLAP;
using fflow.body;
using fflow.body.providers;
using fflow.body.builtinactioncommands;
using fflow.console.providers;

namespace fflow.console
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var session = new SessionRepository ();
			var console = new ConsoleProvider ();
			var wfprov = new WorkflowProvider ();
			var proc = new ProcessProvider ();
			var configrepo = new WorkflowConfigRepository ();
			var exec = new ActionCommands (new PushActionCommand(wfprov));
			var body = new Body (wfprov, proc, configrepo, exec);
			var head = new Head (session, console, body);
			Parser.Run<Head> (args, head);
		}
	}
}