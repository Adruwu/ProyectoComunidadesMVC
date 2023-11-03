using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers.Interfaces;

namespace ProyectoComunidades.Controllers.Checks
{
	public class CheckPasswordMatch : ICheckStrategy
	{
		public bool Check(params string[] inputs)
		{
			if (inputs.Length != 2)
			{
				throw new ArgumentException("Se esperan exactamente dos valores para la validación de contraseña.");
			}

			if (inputs[0] != inputs[1])
			{
				Console.WriteLine("ERROR: Passwords don't match");
				return false;
			}
			return true;
		}
	}
}
