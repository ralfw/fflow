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
			var head = new Head (session);
			Parser.Run<Head> (args, head);
		}
	}
}