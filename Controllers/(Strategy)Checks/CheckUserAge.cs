using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers.Interfaces;

namespace ProyectoComunidades.Controllers.Checks
{
	public class CheckUserAge : ICheckStrategy
	{
		public bool Check(params string[] inputs)
		{
			string dateFormat = "dd/MM/yyyy";
			if (DateTime.TryParseExact(inputs[0], dateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime date))
			{
				if (CheckAdultAge(date))
				{
					return true;
				}
			}
			else
			{
				Console.WriteLine("ERROR: Enter the correct format");
			}
			return false;
		}
		public bool CheckAdultAge(DateTime birthDate)
		{
			DateTime currentDate = DateTime.Now;
			int ageInYears = currentDate.Year - birthDate.Year;
			if (currentDate.Month < birthDate.Month || currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day)
			{
				ageInYears--;
			}
			if (!(ageInYears >= 18))
			{
				Console.WriteLine("You must be of legal age to register");
				return false;
			}
			return true;
		}

	}
}
