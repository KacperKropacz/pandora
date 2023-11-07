using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backendy.Models;

namespace backendy_v2.Controllers
{
    public class UserTablesController : Controller
    {
        private readonly backendDBContext _context;

        public UserTablesController(backendDBContext context)
        {
            _context = context;
        }

        // GET: UserTables
        public async Task<IActionResult> Index()
        {
              return _context.user_table != null ? 
                          View(await _context.user_table.ToListAsync()) :
                          Problem("Entity set 'backendDBContext.user_table'  is null.");
        }

        // GET: UserTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.user_table == null)
            {
                return NotFound();
            }

            var userTable = await _context.user_table
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userTable == null)
            {
                return NotFound();
            }

            return View(userTable);
        }

        // GET: UserTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Password,UserIcon,Email")] UserTable userTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTable);
        }

        // GET: UserTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.user_table == null)
            {
                return NotFound();
            }

            var userTable = await _context.user_table.FindAsync(id);
            if (userTable == null)
            {
                return NotFound();
            }
            return View(userTable);
        }

        // POST: UserTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Password,UserIcon,Email")] UserTable userTable)
        {
            if (id != userTable.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTableExists(userTable.UserId))
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
            return View(userTable);
        }

        // GET: UserTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.user_table == null)
            {
                return NotFound();
            }

            var userTable = await _context.user_table
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userTable == null)
            {
                return NotFound();
            }

            return View(userTable);
        }

        // POST: UserTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.user_table == null)
            {
                return Problem("Entity set 'backendDBContext.user_table'  is null.");
            }
            var userTable = await _context.user_table.FindAsync(id);
            if (userTable != null)
            {
                _context.user_table.Remove(userTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTableExists(int id)
        {
          return (_context.user_table?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
