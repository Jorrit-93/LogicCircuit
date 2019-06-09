using LogicCircuit.Models.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCircuit.Interfaces
{
	interface IMediator
	{
		void Notify(BaseComponent sender, EventArgs dialog);
	}
}
