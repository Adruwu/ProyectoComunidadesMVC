using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers.Interfaces;

namespace ProyectoComunidades.Controllers.Checks
{
	public class CheckEmailLength : ICheckStrategy
	{
		public bool Check(params string[] inputs)
		{
			if (inputs[0].Length > 40)
			{
				Console.WriteLine("ERROR: Emails longer than 40 characters are not accepted");
				return false;
			}
			return true;
		}

	}
}
