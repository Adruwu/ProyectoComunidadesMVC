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
			if (inputs == null || inputs.Length == 0)
			{
				throw new ArgumentException("No se proporcionaron datos de edad.");
			}

			if (int.TryParse(inputs[0], out int userAge))
			{
				return userAge >= 18;
			}
			else
			{
				throw new ArgumentException("El dato de edad no es un número válido.");
			}
		}

	}
}
