using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers;
using ProyectoComunidades.Controllers.Interfaces;
using ProyectoComunidadesRelativo.Models;

namespace ProyectoComunidades.Controllers.Checks
{
    public class Checks : IChecks
    {

		private ICheckStrategy _checkStrategy;
		public Checks() { }
		public Checks(ICheckStrategy strategy)
		{
			_checkStrategy = strategy;
		}
		

		public bool ValidateInput(params string[] inputs)
		{
			return _checkStrategy.Check(inputs);
		}

		public bool CheckUserRepeated(string username, GenericList<User> userlist)
		{
			if (userlist.GetList().Any(user => user.Username == username))
			{
				Console.WriteLine("The username is already in use.");
				return false;
			}
			return true;
		}
        public int GetAdultAge(string birth)
        {
            string dateFormat = "dd/MM/yyyy";
            if (DateTime.TryParseExact(birth, dateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime date))
            { }
            int age = DateTime.Now.Year - date.Year;
            if (DateTime.Now.Month < date.Month || DateTime.Now.Month == date.Month && DateTime.Now.Day < date.Day)
            {
                age--;
            }
            return age;
        }
    }
}
