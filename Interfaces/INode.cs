using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Models
{
	interface INode
	{
		string GetName();
		void AddNode(INode node);
		List<INode> GetNodes();

		void Switch(bool value);
		bool Calculate();
		List<INode> Validate(List<INode> nodeNames);
	}
}
