using LogicCircuit.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Models
{
	class Circuit
	{
		private List<InputNode> inputs = new List<InputNode>();
		private List<INode> centers = new List<INode>();
		private List<INode> outputs = new List<INode>();


		public List<InputNode> GetInputNodes()
		{
			return inputs;
		}
		public List<INode> GetCenterNodes()
		{
			return centers;
		}

		public List<INode> GetOutputNodes()
		{
			return outputs;
		}

		public void AddInputNode(InputNode node)
		{
			inputs.Add(node);
		}

		public void AddCenterNode(INode node)
		{
			centers.Add(node);
		}

		public void AddOutputNode(INode node)
		{
			outputs.Add(node);
		}

		public int Validate()
		{
			foreach (INode node in outputs)
			{
				List<INode> tempNodeList = new List<INode>();
				tempNodeList = node.Validate(tempNodeList);
				INode lastNode = tempNodeList.Last();
				tempNodeList.RemoveAt(tempNodeList.Count - 1);
				if (lastNode.GetType().BaseType != typeof(InputNode))
				{
					if(tempNodeList.Contains(lastNode))
					{
						return 2;
					}
					return 1;
				}
			}
			return 0;
		}
	}
}
