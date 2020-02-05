using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PcRepaire.Data;
using PcRepaire.Models;

namespace PcRepaire.Controllers
{
    public class EquipUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EquipUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EquipUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.EquipUsers.ToListAsync());
        }

        // GET: EquipUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipUser = await _context.EquipUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipUser == null)
            {
                return NotFound();
            }

            return View(equipUser);
        }

        // GET: EquipUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName")] EquipUser equipUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipUser);
        }

        // GET: EquipUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipUser = await _context.EquipUsers.FindAsync(id);
            if (equipUser == null)
            {
                return NotFound();
            }
            return View(equipUser);
        }

        // POST: EquipUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName")] EquipUser equipUser)
        {
            if (id != equipUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipUserExists(equipUser.Id))
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
            return View(equipUser);
        }

        // GET: EquipUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipUser = await _context.EquipUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipUser == null)
            {
                return NotFound();
            }

            return View(equipUser);
        }

        // POST: EquipUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipUser = await _context.EquipUsers.FindAsync(id);
            _context.EquipUsers.Remove(equipUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipUserExists(int id)
        {
            return _context.EquipUsers.Any(e => e.Id == id);
        }
    }
}
