using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			//12.12.2020
		}
		public static bool CheckDate(string str)
		{
			if (str[2] == '.' || str[5] == '.')
			{
				string[] check = str.Split('.');

			}
			else return false;




			return true;
		}
	}
}
