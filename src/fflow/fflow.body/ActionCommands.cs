using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using fflow.body.providers;
using fflow.body.data;

namespace fflow.body
{
	public class ActionCommands {
		IActionCommand[] buildinCommands;

		public ActionCommands(params IActionCommand[] buildinCommands) {
			this.buildinCommands = buildinCommands;
		}

		public string Execute(string workflowpath, string documentpath, string selectedActionname, IEnumerable<WorkflowAction> actions) {
			var action = actions.First (a => a.Name == selectedActionname);

			if (action.Command.StartsWith ("@")) {
				var cmd = this.buildinCommands.FirstOrDefault (c => c.Name == action.Command);
				if (cmd != null)
					return cmd.Execute(workflowpath, documentpath, action.Args);
				else
					throw new ArgumentException ("Unkown built-in command: " + selectedActionname);
			} else
				throw new NotImplementedException ("Custom action handling not implemented yet!");
		}
	}
}