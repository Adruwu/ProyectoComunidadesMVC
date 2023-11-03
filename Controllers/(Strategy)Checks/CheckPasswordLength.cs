using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers.Interfaces;

namespace ProyectoComunidades.Controllers.Checks
{
	public class CheckPasswordLength : ICheckStrategy
	{
		public bool Check(params string[] inputs)
		{
			if (inputs[0].Length < 8)
			{
				Console.WriteLine("ERROR: The password must be at least 8 characters.");
				return false;
			}
			return true;
		}
	}

}
