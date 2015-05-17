using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using fflow.body.providers;
using fflow.body.data;

namespace fflow.body
{
	public delegate string WorkflowCommandDelegate(string workflowpath, string documentpath, string actionname);

	public class Executor {
		Dictionary<string, WorkflowCommandDelegate> buildinCommands;

		public Executor(WorkflowProvider wfprov) {
			this.buildinCommands = new Dictionary<string, WorkflowCommandDelegate> { 
				{"@push", (workflowpath, documentpath, destinationStationname) =>
								wfprov.Push_document (documentpath, workflowpath, destinationStationname)
				}
			};
		}

		public string Run(string workflowpath, string documentpath, string selectedActionname, IEnumerable<WorkflowAction> actions) {
			var action = actions.First (a => a.Name == selectedActionname);

			if (action.Command.StartsWith ("@")) {
				if (this.buildinCommands.ContainsKey (action.Command))
					return this.buildinCommands [action.Command] (workflowpath, documentpath, action.Args);
				else
					throw new ArgumentException ("Unkown build-in command: " + selectedActionname);
			} else
				throw new NotImplementedException ("Custom action handling not implemented yet!");
		}
	}
}