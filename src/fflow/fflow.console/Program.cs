using System;
using CLAP;
using System.IO;

namespace fflow.console
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var session = new Session ();
			var filesys = new FilesystemProvider ();
			var proc = new ProcessProvider ();
			var head = new Head (session, filesys, proc);
			Parser.Run<Head> (args, head);
		}
	}
}