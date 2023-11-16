using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoComunidades.Controllers._Factory_StrategyFactory;
using ProyectoComunidades.Services;
using ProyectoComunidadesRelativo.DB;
using ProyectoComunidadesRelativo.Models;

namespace ProyectoComunidadesRelativo.Controllers
{
    public class CommunitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
		private readonly StrategyFactory _strategyFactory;

		public CommunitiesController(ApplicationDbContext context, StrategyFactory strategyFactory)
        {
            _context = context;
			_strategyFactory = strategyFactory;
		}

        public async Task<IActionResult> JoinCommunity()
        {
			if (HttpContext.Session.GetString("Username") == null)
			{
				return RedirectToAction("Index", "Home");
			}

			return _context.Communities != null ? 
                          View(await _context.Communities.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Communities'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Communities == null)
            {
                return NotFound();
            }

            var community = await _context.Communities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

		public IActionResult CreateCommunity()
		{
			if (HttpContext.Session.GetString("Username") == null)
			{
				return RedirectToAction("Index", "Home");
			}
			return View();
		}

		[HttpPost]
		public IActionResult CreateCommunity(Community community)
		{
			if (ModelState.IsValid)
			{
                // ID del usuario de la sesión en el objeto Community
                int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
				community.Creator_id = userId;
				_context.Communities.Add(community);
				_context.SaveChanges();
				return RedirectToAction("JoinCommunity");
			}
			return View(community);
		}


		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Communities == null)
            {
                return NotFound();
            }

            var community = await _context.Communities.FindAsync(id);
            if (community == null)
            {
                return NotFound();
            }
            return View(community);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Tittle,Theme")] Community community)
		{
			if (id != community.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var existingCommunity = await _context.Communities.FindAsync(id);
					community.Creator_id = existingCommunity.Creator_id;
					_context.Entry(existingCommunity).CurrentValues.SetValues(community);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CommunityExists(community.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction("JoinCommunity", "Communities");
			}
			return View(community);
		}



		public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Communities == null)
            {
                return NotFound();
            }

            var community = await _context.Communities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (community == null)
            {
                return NotFound();
            }

            return View(community);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Communities == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Communities'  is null.");
            }
            var community = await _context.Communities.FindAsync(id);
            if (community != null)
            {
                _context.Communities.Remove(community);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommunityExists(int id)
        {
          return (_context.Communities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
