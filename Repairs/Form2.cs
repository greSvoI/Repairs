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
		Request request = new Request();
		public Request Reques { get => request; set { request = value; } }
		public Form2()
		{
			InitializeComponent();
		}
		public Form2(Request  req)
		{
			InitializeComponent();
			Reques = req;
			textBoxFio.Text = Reques.Fio;
			textBoxDescription.Text = Reques.Description;
			textBoxDate.Text = Reques.Times;
			foreach (var item in comboBoxStatus.Items)
				if (request.Status == item.ToString())
					comboBoxStatus.SelectedItem = item;
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{

			if (Request.CheckFio(textBoxFio.Text) && Request.CheckDate(textBoxDate.Text) && textBoxDescription.Text != "" && comboBoxStatus.SelectedIndex != -1)
			{
				Reques.Fio = textBoxFio.Text;
				Reques.Times = textBoxDate.Text;
				Reques.Description = textBoxDescription.Text;
				Reques.Status = comboBoxStatus.SelectedItem.ToString();
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else MessageBox.Show("Некоректные данные");
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
