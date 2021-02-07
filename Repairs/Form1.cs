using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repairs
{
	public partial class Form1 : Form
	{
		List<Request> requests = new List<Request>();
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			requests = Request.LoadClient();
			foreach (Request item in requests)
				listBox1.Items.Add(item.Fio);
		}

		private void buttonCreate_Click(object sender, EventArgs e)
		{
			Form2 form = new Form2();
			if(form.ShowDialog() == DialogResult.OK)
			{
				Request temp = new Request();
				temp = form.Reques;
				requests.Add(temp);
				listBox1.Items.Add(temp.Fio);
				Request.SaveClient(requests);
			}

		}

		private void buttonEdit_Click(object sender, EventArgs e)
		{
			Form2 form2;
			if (listBox1.SelectedIndex != -1)
			{
				foreach (Request item in requests)
					if (item.Fio == listBox1.SelectedItem.ToString())
					{
						form2 = new Form2(item);
						form2.ShowDialog();
						Request.SaveClient(requests);
					}
			}
			else MessageBox.Show("Выберите клиента");
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			Request.SaveClient(requests);
			this.Close();
		}

		private void buttonSearch_Click(object sender, EventArgs e)
		{
			string temp = "";
			if (textBoxSearch.Text == "Открыта" || textBoxSearch.Text == "В обработке" || textBoxSearch.Text == "Закрыта" || textBoxSearch.Text == "Нерешаемая")
			{
				temp = textBoxSearch.Text;
				listBox1.Items.Clear();
				foreach (Request item in requests)
					if (item.Status == textBoxSearch.Text)
						listBox1.Items.Add(item.Fio);

			}
			else if (Request.CheckFio(textBoxSearch.Text))
			{
				
					temp = textBoxSearch.Text;
					listBox1.Items.Clear();
					foreach (var item in requests)
						if (item.Fio == temp)
						listBox1.Items.Add(item.Fio);
				

			}
			else if(Request.CheckDate(textBoxSearch.Text))
			{
				listBox1.Items.Clear();
				foreach(Request item in requests)
				{
					if (item.Times == textBoxSearch.Text)
						listBox1.Items.Add(item.Fio);

				}
			}
			else if(textBoxSearch.Text!="")
			{
				listBox1.Items.Clear();
				foreach (Request item in requests)
				{
					temp = item.Description;
					if(temp.Contains(textBoxSearch.Text))
					{
						listBox1.Items.Add(item.Fio);
					}

				}
			}
			else MessageBox.Show("Некорректный ввод");
		}

		private void buttonDel_Click(object sender, EventArgs e)
		{
			if(listBox1.SelectedIndex!=-1)
			{
				foreach (Request item in requests)
					if (listBox1.SelectedItem.ToString() == item.Fio)
						listBox1.Items.Remove(item.Fio);
				Request.SaveClient(requests);
			}
		}

		private void buttonReload_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			foreach (Request item in requests)
				listBox1.Items.Add(item.Fio);
		}
	}
}
