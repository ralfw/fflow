using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using fflow.body.providers;
using fflow.body.data;

namespace fflow.body.builtinactioncommands
{
	public class PushActionCommand : IActionCommand {
		WorkflowProvider wfprov;

		public PushActionCommand(WorkflowProvider wfprov) {
			this.wfprov = wfprov;
		}

		#region IActionCommand implementation
		public string Name { get { return "@push"; } }

		public string Execute (string workflowpath, string documentpath, string destinationStationname)
		{
			return wfprov.Push_document (documentpath, workflowpath, destinationStationname);
		}
		#endregion	
	}
}