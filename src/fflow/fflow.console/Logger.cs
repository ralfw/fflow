using System;
using System.Linq;
using System.Diagnostics;
using CLAP;
using System.IO;

namespace fflow.console
{
	interface ILogger {
		void Write (string documentpath, string @event, string info = "");
	}

	class Logger : ILogger {
		public static ILogger Current = new Logger ();

		public void Write(string documentpath, string @event, string info = "") {
			var logentry = string.Format ("{0:O}\t{1}\t{2}\t{3}", DateTime.Now, Environment.UserName, @event, info);
			var logfilepath = documentpath + ".log";
			File.AppendAllLines (logfilepath, new[]{ logentry });
		}
	}
}