using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers.Interfaces;

namespace ProyectoComunidades.Controllers.Checks
{
	public class CheckUsernameLength : ICheckStrategy
	{
		public bool Check(params string[] inputs)
		{
			if (inputs[0].Length < 5)
			{
				Console.WriteLine("ERROR: The User must contain at least 5 characters.");
				return false;
			}
			return true;
		}
	}

}
