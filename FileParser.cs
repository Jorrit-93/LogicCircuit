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


		public List<string> ReadFile(string stream)
		{
			string line;
			List<string> lines = new List<string>();
			try
			{
				StreamReader streamReader = new StreamReader(stream);
				line = streamReader.ReadLine();
				while(line != null)
				{
					lines.Add(line);
					line = streamReader.ReadLine();
				}
				streamReader.Close();
				return lines.ToArray().Where(element => !element.Contains('#')).ToList();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
		}

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
