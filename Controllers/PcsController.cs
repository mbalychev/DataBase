using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PcRepaire.Data;
using PcRepaire.Models;

namespace PcRepaire.Controllers
{
    [Authorize]
    public class PcsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PcsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pcs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pcs.Include(p => p.SoftWare).Include(h => h.HardWare).ToListAsync());
        }

        // GET: Pcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pc = await _context.Pcs.Include(p=>p.HardWare).Include(s=>s.SoftWare)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pc == null)
            {
                return Content("NotFound");
            }

            return View(pc);
        }

        // GET: Pcs/Create
        [Authorize(Roles ="admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pcs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,HardWareId,SoftWareId")] Pc pc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pc);
        }

        // GET: Pcs/Edit/5
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pc = await _context.Pcs.FindAsync(id);
            if (pc == null)
            {
                return NotFound();
            }
            return View(pc);
        }

        // POST: Pcs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,HardWareId,SoftWareId")] Pc pc)
        {
            if (id != pc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PcExists(pc.Id))
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
            return View(pc);
        }

        // GET: Pcs/Delete/5
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Delete(int? id, bool? error = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pc = await _context.Pcs.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (pc == null)
            {
                return NotFound();
            }
            
            if (error == true)
            {
                ViewData["Error"] = "Delite filed, please try a latter";
            }
            
            return View(pc);
        }

        // POST: Pcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pc = await _context.Pcs.FindAsync(id);
            if (pc == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Pcs.Remove(pc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                return RedirectToAction(nameof(Delete), new { id = id, error = true });
            }
        }

        private bool PcExists(int id)
        {
            return _context.Pcs.Any(e => e.Id == id);
        }
    }
}
