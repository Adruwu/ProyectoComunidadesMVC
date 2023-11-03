using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers.Interfaces;

namespace ProyectoComunidades.Controllers.Checks
{
	public class CheckPasswordPattern : ICheckStrategy
	{
		public bool Check(params string[] inputs)
		{
			if (!Regex.IsMatch(inputs[0], @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)"))
			{
				Console.WriteLine("ERROR: The password must have at least 1 Capital Letter and 1 Number.");
				return false;
			}
			return true;
		}
	}
}
