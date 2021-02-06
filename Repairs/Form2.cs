using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Repairs
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}
		public Form2(Request  request)
		{
			InitializeComponent();
			textBoxFio.Text = request.Fio;
			textBoxDescription.Text = request.Description;
			textBoxDate.Text = request.Times;
			foreach (var item in comboBoxStatus.Items)
				if (request.Status == item.ToString())
					comboBoxStatus.SelectedItem = item;

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Request.CheckFio(textBoxFio.Text);
		}
	}
}
