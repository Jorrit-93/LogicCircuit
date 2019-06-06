using LogicCircuit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit
{
	class CircuitController
	{
		private CircuitBuilder builder = new CircuitBuilder();

		public Circuit createCircuit(List<string> nodeList, List<string> edgeList)
		{
			builder.Reset();
			List<INode> nodes = builder.ProcessNodes(nodeList);
			builder.ProcessEdges(edgeList, nodes);
			builder.InstantiateCircuit(nodes);
			if(!builder.Validate())
			{
				return null;
			}
			return builder.GetResult();
		}
	}
}
