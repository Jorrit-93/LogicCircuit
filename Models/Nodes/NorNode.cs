using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Models.Nodes
{
	class NorNode : BaseNode
	{
		public NorNode(string name) : base(name) { }

		public override bool Calculate()
		{
			foreach (INode element in nodes)
			{
				if(element.Calculate())
				{
					return false;
				}
			}
			return true;
		}

		public override List<INode> Validate(List<INode> nodeList)
		{
			if (nodes.Count() != 1)
			{
				return nodeList;
			}
			return base.Validate(nodeList);
		}
	}
}
