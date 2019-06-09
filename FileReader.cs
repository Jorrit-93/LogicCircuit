using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit
{
	class FileReader
	{
		public List<string> ReadFile(string stream)
		{
			string line;
			List<string> lines = new List<string>();
			try
			{
				StreamReader streamReader = new StreamReader(stream);
				line = streamReader.ReadLine();
				while (line != null)
				{
					lines.Add(line);
					line = streamReader.ReadLine();
				}
				streamReader.Close();
				return lines.ToArray().Where(element => !element.Contains('#')).ToList();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return null;
			}
		}
	}
}
