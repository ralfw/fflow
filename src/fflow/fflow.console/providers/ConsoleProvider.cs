using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using CLAP;
using fflow.body;
using fflow.body.data;
using fflow.body.providers;
using fflow.console.providers;

namespace fflow.console.providers
{
	public class ConsoleProvider {
		public void Display(DocumentInfo docinfo) {
			Console.WriteLine ("Document: {0}", docinfo.Documentpath);
			foreach (var logline in docinfo.Loglines)
				Console.WriteLine ("  {0}", logline);
		}

		public void Display(string workflowpath, StationInfo[] stationinfos) {
			Console.WriteLine ("Workflow: {0}", workflowpath);
			Console.WriteLine ("  Stations:");
			foreach (var stationinfo in stationinfos)
				Console.WriteLine ("    {0}", stationinfo.Name);
		}

		public void Display(string workflowpath, StationDetails stationdetails) {
			Console.WriteLine ("Workflow: {0}", workflowpath);
			Console.WriteLine ("  Station: {0} / Available actions: {1}", stationdetails.Name, 
				string.Join (", ", stationdetails.Actionnames));
			Console.WriteLine ("    Inbox:");
			foreach (var docname in stationdetails.InboxDocumentnames)
				Console.WriteLine ("      {0}", docname);
			Console.WriteLine ("    WIP:");
			foreach (var docname in stationdetails.WIPDocumentnames)
				Console.WriteLine ("      {0}", docname);
		}
	}
}