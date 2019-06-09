using LogicCircuit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicCircuit.Models.Components
{
	abstract class BaseComponent
	{
		private Control component;
		protected IMediator dialog;

		protected BaseComponent(Control component, IMediator dialog)
		{
			this.component = component;
			this.dialog = dialog;
		}

		public Control getComponent()
		{
			return component;
		}
	}
}
