using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using fflow.body.providers;
using fflow.body.data;

namespace fflow.body
{
	public class Executor {
		Dictionary<string, Action<string,string,string>> buildinCommands;

		public Executor(WorkflowProvider filesys) {
			this.buildinCommands = new Dictionary<string, Action<string, string, string>>{ 
				{"@push", (workflowpath, documentpath, destinationStationname) => {filesys.Push_document(documentpath, workflowpath, destinationStationname);}}
			};
		}

		public void Run(string workflowpath, string documentpath, string selectedActionname, IEnumerable<WorkflowAction> actions) {
			var action = actions.First (a => a.Name == selectedActionname);

			if (action.Command.StartsWith ("@")) {
				if (this.buildinCommands.ContainsKey (action.Command))
					this.buildinCommands [action.Command] (workflowpath, documentpath, action.Args);
				else
					throw new ArgumentException ("Unkown build-in command: " + selectedActionname);
			} else
				throw new NotImplementedException ("Custom action handling not implemented yet!");
		}
	}
}