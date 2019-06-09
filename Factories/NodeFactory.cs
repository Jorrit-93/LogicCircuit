using LogicCircuit.Models;
using LogicCircuit.Models.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Factories
{
	class NodeFactory
	{

		public INode CreateNode(string name, string node)
		{
			switch(node)
			{
				case "AND":
					return new AndNode(name);
				case "INPUT_HIGH":
					return new InputHighNode(name);
				case "INPUT_LOW":
					return new InputLowNode(name);
				case "NAND":
					return new NandNode(name);
				case "NOR":
					return new NorNode(name);
				case "NOT":
					return new NotNode(name);
				case "OR":
					return new OrNode(name);
				case "PROBE":
					return new ProbeNode(name);
				case "XOR":
					return new XorNode(name);
			}
			return null;
		}

	}
}
