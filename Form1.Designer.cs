using System.Windows.Forms;

namespace LogicCircuit
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listView1 = new System.Windows.Forms.ListView();
			this.listView2 = new System.Windows.Forms.ListView();
			this.listView3 = new System.Windows.Forms.ListView();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.CheckBoxes = true;
			this.listView1.Location = new System.Drawing.Point(12, 42);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(80, 312);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.List;
			this.listView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListView1_ItemCheck);
			// 
			// listView2
			// 
			this.listView2.Location = new System.Drawing.Point(98, 42);
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(640, 312);
			this.listView2.TabIndex = 2;
			this.listView2.UseCompatibleStateImageBehavior = false;
			this.listView2.View = System.Windows.Forms.View.Details;
			// 
			// listView3
			// 
			this.listView3.CheckBoxes = true;
			this.listView3.Location = new System.Drawing.Point(744, 42);
			this.listView3.Name = "listView3";
			this.listView3.Size = new System.Drawing.Size(80, 312);
			this.listView3.TabIndex = 3;
			this.listView3.UseCompatibleStateImageBehavior = false;
			this.listView3.View = System.Windows.Forms.View.List;
			this.listView3.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ListView3_ItemCheck);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "Text|*.txt";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 13);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Open file";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(95, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "";
			this.label1.ForeColor = System.Drawing.Color.Red;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(835, 368);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.listView2);
			this.Controls.Add(this.listView3);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private ListView listView1;
		private ListView listView2;
		private ListView listView3;
		private OpenFileDialog openFileDialog1;
		private Button button1;
		private Label label1;
	}
}

