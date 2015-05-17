using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using fflow.body.providers;
using fflow.body.data;

namespace fflow.body
{
	public interface IActionCommand {
		string Name {get;}
		string Execute(string workflowpath, string documentpath, string parameters);
	}
	
}