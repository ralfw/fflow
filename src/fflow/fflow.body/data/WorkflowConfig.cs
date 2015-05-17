using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace fflow.body.data
{
	public struct WorkflowConfig {
		public WorkflowConfig() {
			this.Actions = new WorkflowAction[0];
		}

		public WorkflowAction[] Actions { get; set; }
	}
		
	public struct WorkflowAction {
		public string Name { get; set; }
		public string Command { get; set; }
		public string Args { get; set; }
	}
}