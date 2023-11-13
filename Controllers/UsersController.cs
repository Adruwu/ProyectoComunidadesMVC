using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoComunidades.Controllers._Factory_StrategyFactory;
using ProyectoComunidades.Controllers.Checks;
using ProyectoComunidadesRelativo.DB;
using ProyectoComunidadesRelativo.Models;

namespace ProyectoComunidadesRelativo.Controllers
{
    public class UsersController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly ValidateCredentials _checkCredentials;
		private readonly StrategyFactory _strategyFactory;
		public UsersController(ApplicationDbContext context, ValidateCredentials checkService, StrategyFactory strategyFactory)
        {
            _context = context;
            _checkCredentials = checkService;
			_strategyFactory = strategyFactory;

		}

        public async Task<IActionResult> Index()
        {
              return _context.Users != null ? 
                          View(await _context.Users.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Users'  is null.");
        }

		public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (_checkCredentials.IsValidUser(model.Username, model.Password))
            {
                return RedirectToAction("Main", "Users");
            }

            // mensaje de error
			ModelState.AddModelError("Password", "Las credenciales no coinciden.");
			return View(model);
        }

        public IActionResult Main()
		{
			return View();
		}

		public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Register()
        {
            return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register([Bind("Id,Username,Pass,ConfirmPassword,Age,Email,Description")] User user)
		{
			if (ModelState.IsValid)
			{
				var usernameLengthChecker = _strategyFactory.CreateCheckStrategy("UsernameLength");
				if (!usernameLengthChecker.Check(user.Username))
				{
					ModelState.AddModelError("Username", "ERROR: The Username must have at least 5 characters.");
					return View(user);
				}

				var usernamePatternChecker = _strategyFactory.CreateCheckStrategy("UsernamePattern");
				if (!usernamePatternChecker.Check(user.Username))
				{
					ModelState.AddModelError("Username", "ERROR: The Username must contain at least 1 Capital Letter and 1 Number.");
					return View(user);
				}

                var passwordLegnthChecker = _strategyFactory.CreateCheckStrategy("PasswordLength");
                if (!passwordLegnthChecker.Check(user.Pass))
                {
                    ModelState.AddModelError("Pass", "ERROR: The password must be at least 8 characters.");
                    return View(user);
                }

                var passwordPatternChecker = _strategyFactory.CreateCheckStrategy("PasswordPattern");
				if (!passwordPatternChecker.Check(user.Pass))
				{
					ModelState.AddModelError("Pass", "ERROR: The Password must have at least 1 Capital Letter and 1 Number.");
					return View(user);
				}

                var passwordMatchChecker = _strategyFactory.CreateCheckStrategy("PasswordMatch");
                if (!passwordMatchChecker.Check(user.ConfirmPassword, user.Pass))
                {
                    ModelState.AddModelError("ConfirmPassword", "ERROR: Passwords do not match.");
                    return View(user);
                }

                string ageAsString = user.Age.ToString();
				var AgeChecker = _strategyFactory.CreateCheckStrategy("UserAge");
				if (!AgeChecker.Check(ageAsString))
				{
					ModelState.AddModelError("Age", "ERROR: You must be at least 18 years old to register.");
					return View(user);
				}

				var emailLengthChecker = _strategyFactory.CreateCheckStrategy("EmailLength");
				if (!emailLengthChecker.Check(user.Email))
				{
					ModelState.AddModelError("Email", "ERROR: Emails longer than 40 characters are not accepted.");
					return View(user);
				}

				var emailChecker = _strategyFactory.CreateCheckStrategy("UserEmail");
				if (!emailChecker.Check(user.Email))
				{
					ModelState.AddModelError("Email", "ERROR: The email doesn't meet the proper format.");
					return View(user);
				}

                var descriptionChecker = _strategyFactory.CreateCheckStrategy("DescriptionLength");
                if (!descriptionChecker.Check(user.Description))
                {
                    ModelState.AddModelError("Description", "ERROR: Description cannot exceed 200 letters.");
                    return View(user);
                }

                _context.Add(user);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index", "Home");
			}

			return View(user);
		}

		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Pass,Age,Email,Description")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
