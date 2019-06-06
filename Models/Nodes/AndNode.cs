using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Models
{
	class AndNode : BaseNode
	{
		public AndNode(string name) : base(name) { }

		public override bool Calculate()
		{
			return nodes.TrueForAll(element => element.Calculate());
		}

		public override List<INode> Validate(List<INode> nodeList)
		{
			if (nodes.Count() < 2)
			{
				return nodeList;
			}
			return base.Validate(nodeList);
		}
	}
}
