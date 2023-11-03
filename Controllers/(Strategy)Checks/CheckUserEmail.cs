using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers.Interfaces;

namespace ProyectoComunidades.Controllers.Checks
{
	public class CheckUserEmail : ICheckStrategy
	{
		public bool Check(params string[] inputs)
		{
			if (!Regex.IsMatch(inputs[0], @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
			{
				Console.WriteLine("ERROR: The email doesn't meet the proper format");
				return false;
			}
			return true;
		}

	}
}
