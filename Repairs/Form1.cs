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
			using(StreamReader sr = new StreamReader("remote.txt"))
			{
				try
				{
					while (true)
					{
						Request temp = new Request();
						
						temp.Fio = sr.ReadLine();
						temp.Description = sr.ReadLine();
						temp.Times = sr.ReadLine();
						temp.Status = sr.ReadLine();
						requests.Add(temp);
						if (sr.EndOfStream) break;
					}
					foreach (Request item in requests)
						listBox1.Items.Add(item.Fio);
				}
				catch (Exception ex)
				{

					MessageBox.Show(ex.Message);
				}
			}





		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form2 form = new Form2();
			form.ShowDialog();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Form2 form2 ;
			if (listBox1.SelectedIndex != -1)
			{
				foreach (Request item in requests)
					if (item.Fio == listBox1.SelectedItem.ToString())
					{
						form2 = new Form2(item);
						form2.ShowDialog();
					}
			}
		}
	}
}
