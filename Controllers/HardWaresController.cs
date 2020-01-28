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
    public class HardWaresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HardWaresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HardWares
        public async Task<IActionResult> Index()
        {
            return View(await _context.HardWares.ToListAsync());
        }

        // GET: HardWares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardWare = await _context.HardWares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardWare == null)
            {
                return NotFound();
            }

            return View(hardWare);
        }

        // GET: HardWares/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: HardWares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("Id,HardType")] HardWare hardWare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hardWare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hardWare);
        }

        // GET: HardWares/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardWare = await _context.HardWares.FindAsync(id);
            if (hardWare == null)
            {
                return NotFound();
            }
            return View(hardWare);
        }

        // POST: HardWares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HardType")] HardWare hardWare)
        {
            if (id != hardWare.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hardWare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HardWareExists(hardWare.Id))
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
            return View(hardWare);
        }

        // GET: HardWares/Delete/5.
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardWare = await _context.HardWares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardWare == null)
            {
                return NotFound();
            }

            return View(hardWare);
        }

        // POST: HardWares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hardWare = await _context.HardWares.FindAsync(id);
            _context.HardWares.Remove(hardWare);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HardWareExists(int id)
        {
            return _context.HardWares.Any(e => e.Id == id);
        }
    }
}
