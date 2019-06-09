using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicCircuit.Interfaces;

namespace LogicCircuit.Models.Components
{
	class ButtonComponent : BaseComponent
	{
		public ButtonComponent(Button component, IMediator dialog) : base(component, dialog)
		{
			component.Click += new EventHandler(Click);
		}

		public void Click(object sender, EventArgs e)
		{
			dialog.Notify(this, e);
		}
	}
}
