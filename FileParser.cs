using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicCircuit
{
	class FileParser
	{
		public List<string> GetNodeList(List<string> lines)
		{
			List<string> returnValue = lines;
			returnValue = returnValue.ToArray().Take(returnValue.FindIndex(element => element.Equals(""))).ToList();
			Regex regex = new Regex("[a-zA-Z0-9]*:\\s+[a-zA-Z0-9_,]*\\w;");
			if(returnValue.Count > 0 && returnValue.TrueForAll(element => regex.IsMatch(element)))
			{
				return returnValue;
			}
			return null;
		}

		public List<string> GetEdgeList(List<string> lines)
		{
			List<string> returnValue = lines.ToArray().Reverse().ToList();
			returnValue = returnValue.Take(returnValue.FindIndex(element => element.Equals(""))).Reverse().ToList();
			Regex regex = new Regex("[a-zA-Z0-9]*:\\s+[a-zA-Z0-9_,]*\\w;");
			if(returnValue.Count > 0 && returnValue.TrueForAll(element => regex.IsMatch(element)))
			{
				return returnValue;
			}
			return null;
		}
	}
}
