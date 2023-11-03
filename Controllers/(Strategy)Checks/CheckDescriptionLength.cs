using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers.Interfaces;

namespace ProyectoComunidades.Controllers.Checks
{

	public class CheckDescriptionLength : ICheckStrategy
	{
		public bool Check(params string[] inputs)
		{
			if (inputs[0].Length > 200)
			{
				Console.WriteLine("ERROR: Description cannot exceed 200 letters");
				return false;
			}
			return true;
		}

	}
}
