using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoComunidades.Controllers.Checks;
using ProyectoComunidades.Controllers.Interfaces;

namespace ProyectoComunidades.Controllers._Factory_StrategyFactory
{
	public class StrategyFactory
	{
		public ICheckStrategy CreateCheckStrategy(string strategyType)
		{
			switch (strategyType)
			{
				case "DescriptionLength":
					return new CheckDescriptionLength();
				case "EmailLength":
					return new CheckEmailLength();
				case "PasswordLength":
					return new CheckPasswordLength();
				case "PasswordMatch":
					return new CheckPasswordMatch();
				case "PasswordPattern":
					return new CheckPasswordPattern();
				case "UserAge":
					return new CheckUserAge();
				case "UserEmail":
					return new CheckUserEmail();
				case "UsernameLength":
					return new CheckUsernameLength();
				case "UsernamePattern":
					return new CheckUsernamePattern();

				default:
					throw new ArgumentException("Invalid Strategy.");
			}
		}
	}

}
