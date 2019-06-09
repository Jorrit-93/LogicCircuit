using LogicCircuit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicCircuit.Models.Components
{
	class ListViewComponent: BaseComponent
	{
		public ListViewComponent(ListView component, IMediator dialog) : base(component, dialog)
		{
			component.ItemCheck += new ItemCheckEventHandler(ItemCheck);
		}

		public void ItemCheck(object sender, ItemCheckEventArgs e)
		{
			dialog.Notify(this, e);
		}
	}
}
