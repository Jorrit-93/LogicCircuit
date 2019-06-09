using LogicCircuit.Factories;
using LogicCircuit.Models;
using LogicCircuit.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit
{
	class CircuitBuilder
	{
		private NodeFactory nodeFactory = new NodeFactory();
		private Circuit circuit;

		public void Reset()
		{
			circuit = new Circuit();
		}

		public List<INode> ProcessNodes(List<string> lines)
		{
			List<INode> nodeList = new List<INode>();

			if(lines != null)
			{
				lines.ToArray().Where(element => !element.Equals("")).ToList().ForEach(element =>
				{
					string nodeName = Substring(element, 0, element.IndexOf(':'));
					int index = element.LastIndexOf('\t');
					int space = element.LastIndexOf(' ');
					if (index < space)
					{
						index = space;
					}
					string nodeType = Substring(element, index + 1, element.IndexOf(';'));
					//Console.WriteLine(nodeName + " - " + node);

					nodeList.Add(nodeFactory.CreateNode(nodeName, nodeType));
				});
			}

			return nodeList;
		}

		public void ProcessEdges(List<string> lines, List<INode> nodes)
		{
			if (lines != null && nodes != null)
			{
					lines.ToArray().Where(element => !element.Equals("")).ToList().ForEach(element =>
				{
					string edgeName = Substring(element, 0, element.IndexOf(":"));
					int index = element.LastIndexOf('\t');
					int space = element.LastIndexOf(' ');
					if (index < space)
					{
						index = space;
					}
					List<string> edgeList = (Substring(element, index + 1, element.IndexOf(";"))).Split(',').ToList();
					//Console.Write(edgeName);
					//edges.ForEach(test => Console.Write(" - " + test));
					//Console.WriteLine();

					INode edge = nodes.Find(element1 => element1.GetName().Equals(edgeName));

					List<INode> edges = new List<INode>();
					edgeList.ForEach(element1 =>
					{
						edges.Add(nodes.Find(element2 => element2.GetName().Equals(element1)));
					});

					edges.ForEach(element3 => element3.AddNode(edge));
				});
			}
		}

		public void InstantiateCircuit(List<INode> nodes)
		{
			nodes.ForEach(element =>
			{
				if(element.GetType().BaseType == typeof(InputNode))
				{
					circuit.AddInputNode((InputNode)element);
				}
				else if (element.GetType() == typeof(ProbeNode))
				{
					circuit.AddOutputNode(element);
				}
				else
				{
					circuit.AddCenterNode(element);
				}
			});
		}

		public Circuit GetResult()
		{
			return circuit;
		}

		private string Substring(string input, int firstIndex, int lastIndex)
		{
			return input.Substring(firstIndex, lastIndex - firstIndex);
		}
	}
}
