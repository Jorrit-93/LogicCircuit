using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Models
{
	abstract class BaseNode : INode
	{
		protected string name;
		protected List<INode> nodes = new List<INode>();

		protected BaseNode(string name)
		{
			this.name = name;
		}

		public string GetName()
		{
			return name;
		}

		public void AddNode(INode node)
		{
			nodes.Add(node);
		}

		public List<INode> GetNodes()
		{
			return nodes;
		}

		public virtual void Switch(bool value) { }

		public abstract bool Calculate();

		public virtual List<INode> Validate(List<INode> nodeList)
		{
			if (!nodeList.Contains(this))
			{
				nodeList.Add(this);
				List<INode> tempNodeList = nodeList;
				foreach (INode node in nodes)
				{
					tempNodeList = nodeList.GetRange(0, nodeList.Count);
					tempNodeList = node.Validate(tempNodeList);
					if(!tempNodeList.Last().GetType().Name.StartsWith("Input"))
					{
						return tempNodeList;
					}
				}
				nodeList = tempNodeList;
			}
			return nodeList;
		}
	}
}
