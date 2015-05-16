using System;
using CLAP;
using System.IO;

namespace fflow.console
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var session = new SessionRepository ();
			var filesys = new WorkflowProvider ();
			var proc = new ProcessProvider ();
			var configrepo = new WorkflowConfigRepository ();
			var exec = new Executor (filesys);
			var head = new Head (session, filesys, proc, configrepo, exec);
			Parser.Run<Head> (args, head);
		}
	}
}