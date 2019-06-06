using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Models
{
	class OrNode : BaseNode
	{
		public OrNode(string name) : base(name) { }

		public override bool Calculate()
		{
			foreach(INode element in nodes)
			{
				if(element.Calculate())
				{
					return true;
				}
			}
			return false;
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
