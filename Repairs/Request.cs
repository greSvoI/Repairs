using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repairs
{
	public class Request
	{
		private string fio;
		private string description;
		private string time;
		private string status;
		public string Fio { get=>fio; set { fio = value; } }
		public string Description { get=>description; set { description = value; } }
		public string Times { get=>time; set { time = value; } }
		public string Status { get => status; set { status = value; } }

		public static List<Request> LoadClient()
		{
			List<Request> requests = new List<Request>();
			using (StreamReader sr = new StreamReader("client.txt"))
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
						sr.ReadLine();
						if (sr.EndOfStream) 
							break;
					}
					
				}
				catch (Exception ex)
				{

					MessageBox.Show(ex.Message);
				}
			}
			return requests;
		}
		public static void SaveClient(List<Request> requests)
		{
			using(StreamWriter sw = new StreamWriter("client.txt"))
			{
				foreach(Request item in requests)
				{
					sw.WriteLine(item.Fio);
					sw.WriteLine(item.Description);
					sw.WriteLine(item.Times);
					sw.WriteLine(item.Status);
					sw.WriteLine();
				}
			}
		}

		public static bool CheckFio(string str)
		{
			string[] check = str.Split(' ');
			for (int i = 0; i < check.Length; i++)
			{
				if (!char.IsUpper(check[i].First()))
					return false;
				if(!check[i].Any(x=>char.IsLetter(x)))
					return false;
			}
			return true;
			
		}
		public static bool CheckDate(string str)
		{

			try
			{

				if (str[2] == '.' && str[5] == '.')
				{
					string[] check = str.Split('.');
					for (int i = 0; i < check.Length; i++)
					if (!check[i].All(x => char.IsDigit(x))) return false;
					if (check[2].Length > 4) return false;	
					int year = int.Parse(check[2]);
					int month = int.Parse(check[1]);
					int day = int.Parse(check[0]);

					if (month < 1 || month > 12) return false;
					if (month == 1 && month == 3 && month == 5 && month == 7 && month == 8 && month == 10 && month == 12)
					{
						
						if (day > 31 || day < 1) return false;
					}
					else if (month==2) 
					{
						if (year % 4 == 0)
							if (day > 29 && day < 1) return false;
						else
							if (day > 28 && day < 1) return false;
					}
					else
					{
						if (day > 30 || day < 1) return false;
					}

				}
				else return false;
			}
			catch (Exception ex)
			{
				return false;
			}

			return true;
		}
	}
}
