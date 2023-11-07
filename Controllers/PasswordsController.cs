using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoComunidadesRelativo.DB;
using ProyectoComunidadesRelativo.Models;

namespace ProyectoComunidadesRelativo.Controllers
{
    public class PasswordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PasswordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Passwords
        public async Task<IActionResult> Index()
        {
              return _context.Passwords != null ? 
                          View(await _context.Passwords.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Password'  is null.");
        }

        // GET: Passwords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Passwords == null)
            {
                return NotFound();
            }

            var password = await _context.Passwords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (password == null)
            {
                return NotFound();
            }

            return View(password);
        }

        // GET: Passwords/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passwords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User_id,Pass")] Password password)
        {
            if (ModelState.IsValid)
            {
                _context.Add(password);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(password);
        }

        // GET: Passwords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Passwords == null)
            {
                return NotFound();
            }

            var password = await _context.Passwords.FindAsync(id);
            if (password == null)
            {
                return NotFound();
            }
            return View(password);
        }

        // POST: Passwords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User_id,Pass")] Password password)
        {
            if (id != password.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(password);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasswordExists(password.Id))
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
            return View(password);
        }

        // GET: Passwords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Passwords == null)
            {
                return NotFound();
            }

            var password = await _context.Passwords
                .FirstOrDefaultAsync(m => m.Id == id);
            if (password == null)
            {
                return NotFound();
            }

            return View(password);
        }

        // POST: Passwords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Passwords == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Password'  is null.");
            }
            var password = await _context.Passwords.FindAsync(id);
            if (password != null)
            {
                _context.Passwords.Remove(password);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasswordExists(int id)
        {
          return (_context.Passwords?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
