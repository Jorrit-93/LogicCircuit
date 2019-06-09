using LogicCircuit.Interfaces;
using LogicCircuit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicCircuit.Models.Components;

namespace LogicCircuit
{
	partial class Form1 : Form, IMediator
	{
		Circuit circuit;
		FileReader fileReader;
		FileParser fileParser;
		CircuitController controller;
		List<BaseComponent> mediatorComponents;

		public Form1()
		{
			InitializeComponent();

			fileReader = new FileReader();
			fileParser = new FileParser();
			controller = new CircuitController();

			mediatorComponents = new List<BaseComponent>();
			mediatorComponents.Add(new ListViewComponent(listView1, this));
			mediatorComponents.Add(new ListViewComponent(listView3, this));
			mediatorComponents.Add(new ButtonComponent(button1, this));
		}

		private void Calculate()
		{
			foreach (ListViewItem item in listView3.Items)
			{
				item.Checked = circuit.GetOutputNodes().Find(element => element.GetName().Equals(item.Text)).Calculate();
			}
			listView2.Items.Clear();
			foreach (INode node in circuit.GetCenterNodes())
			{
				ListViewItem newItem = new ListViewItem(node.GetName());
				node.GetNodes().ForEach(element =>
				{
					newItem.SubItems.Add(element.GetName());
					newItem.SubItems.Add(element.Calculate().ToString());
				});
				listView2.Items.Add(newItem);
			}
		}

		public void Notify(BaseComponent sender, EventArgs dialog)
		{
			if (Equals(sender.getComponent(), listView1))
			{
				ItemCheckEventArgs e = (ItemCheckEventArgs)dialog;
				; circuit.GetInputNodes().Find(element => element.GetName().Equals((listView1.Items[e.Index].Text))).Switch(e.NewValue == CheckState.Checked);
				Calculate();
			}
			if (Equals(sender.getComponent(), listView3))
			{
				ItemCheckEventArgs e = (ItemCheckEventArgs)dialog;
				if (circuit.GetOutputNodes().Find(element => element.GetName().Equals(listView3.Items[e.Index].Text)).Calculate())
				{
					e.NewValue = CheckState.Checked;
				}
				else
				{
					e.NewValue = CheckState.Unchecked;
				}
			}
			if (Equals(sender.getComponent(), button1))
			{
				openFileDialog1.ShowDialog();
				if (!openFileDialog1.FileName.Equals("openFileDialog1"))
				{
					ResetForm();
					CreateCircuit();
				}
				else
				{
					label1.Text = "Please select a file";
				}
			}
		}

		private void ResetForm()
		{
			label1.Text = "";
			circuit = null;
			listView1.Items.Clear();
			listView2.Items.Clear();
			listView2.Columns.Clear();
			listView3.Items.Clear();
		}

		private void CreateCircuit()
		{
			List<string> lines = fileReader.ReadFile(openFileDialog1.FileName);
			List<string> nodes = fileParser.GetNodeList(lines);
			List<string> edges = fileParser.GetEdgeList(lines);
			circuit = controller.createCircuit(nodes, edges);
			switch (circuit.Validate())
			{
				case(0):
					if (nodes != null && edges != null)
					{
						FillForm();
					}
					else
					{
						label1.Text = "File could not compile";
					}
					break;
				case(1):
					label1.Text = "Circuit not fully closed";
					break;
				case(2):
					label1.Text = "Infinite loop detected";
					break;
			}
		}

		private void FillForm()
		{
			//listView1
			circuit.GetInputNodes().ForEach(element => listView1.Items.Add(new ListViewItem(element.GetName())));

			//listView2
			int columnAmount = 0;
			circuit.GetCenterNodes().ForEach(element =>
			{
				int newAmount = element.GetNodes().Count;
				if (columnAmount < newAmount)
				{
					columnAmount = newAmount;
				}
			});
			listView2.Columns.Add("node");
			for (int i = 0; i < columnAmount; i++)
			{
				listView2.Columns.Add("input " + (i + 1));
				listView2.Columns.Add("value " + (i + 1));
			}
			listView2.Columns[0].Width = (listView2.Width / (columnAmount + 1)) - 5;
			for (int i = 1; i < listView2.Columns.Count; i++)
			{
				listView2.Columns[i].Width = ((listView2.Width / (columnAmount + 1)) - 5) / 2;
			}

			//listView3
			circuit.GetOutputNodes().ForEach(element => listView3.Items.Add(new ListViewItem(element.GetName())));
			Calculate();
		}
	}
}
