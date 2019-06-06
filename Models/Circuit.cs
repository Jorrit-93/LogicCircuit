using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Models
{
	class Circuit
	{
		private List<INode> inputs = new List<INode>();
		private List<INode> centers = new List<INode>();
		private List<INode> outputs = new List<INode>();


		public List<INode> GetInputNodes()
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

		public void AddInputNode(INode node)
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

		public bool Validate()
		{
			foreach (INode node in outputs)
			{
				List<INode> tempNodeList = new List<INode>();
				tempNodeList = node.Validate(tempNodeList);
				if(!tempNodeList.Last().GetType().Name.StartsWith("Input"))
				{
					return false;
				}
			}
			return true;
		}
	}
}
