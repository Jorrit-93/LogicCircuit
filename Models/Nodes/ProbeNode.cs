using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Models
{
	class ProbeNode : BaseNode
	{
		public ProbeNode(string name) : base(name) { }

		public override bool Calculate()
		{
			return nodes.First().Calculate();
		}

		public override List<INode> Validate(List<INode> nodeList)
		{
			if(nodes.Count() != 1)
			{
				return nodeList;
			}
			return base.Validate(nodeList);
		}
	}
}
