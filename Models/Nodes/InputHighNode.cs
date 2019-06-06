using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Models
{
	class InputHighNode : BaseNode
	{
		private bool value = false;

		public InputHighNode(string name) : base(name) { }

		public override void Switch(bool value)
		{
			this.value = value;
		}

		public override bool Calculate()
		{
			return value;
		}

		public override List<INode> Validate(List<INode> nodeList)
		{
			if (nodes.Count() != 0)
			{
				return nodeList;
			}
			return base.Validate(nodeList);
		}
	}
}
