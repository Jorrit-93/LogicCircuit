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

namespace LogicCircuit
{
	partial class Form1 : Form
	{
		Circuit circuit;
		FileParser fileParser;
		CircuitController controller;
		public Form1()
		{
			InitializeComponent();
			this.fileParser = new FileParser();
			this.controller = new CircuitController();
		}

		private void Calculate()
		{
			foreach(ListViewItem item in listView3.Items)
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

		private void ListView1_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			circuit.GetInputNodes().Find(element => element.GetName().Equals((listView1.Items[e.Index].Text))).Switch(e.NewValue == CheckState.Checked);
			Calculate();
		}

		private void ListView3_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if(circuit.GetOutputNodes().Find(element => element.GetName().Equals(listView3.Items[e.Index].Text)).Calculate())
			{
				e.NewValue = CheckState.Checked;
			}
			else
			{
				e.NewValue = CheckState.Unchecked;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			openFileDialog1.ShowDialog();
			if(!openFileDialog1.FileName.Equals("openFileDialog1"))
			{
				label1.Text = "";
				circuit = null;
				listView1.Items.Clear();
				listView2.Items.Clear();
				listView2.Columns.Clear();
				listView3.Items.Clear();
				List<string> lines = fileParser.ReadFile(openFileDialog1.FileName);
				List<string> nodes = fileParser.GetNodeList(lines);
				List<string> edges = fileParser.GetEdgeList(lines);
				circuit = controller.createCircuit(nodes, edges);

				if (nodes != null && edges != null && circuit != null)
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
				else
				{
					label1.Text = "File could not compile";
				}
			}
			else
			{
				label1.Text = "Please select a file";
			}
		}
	}
}
