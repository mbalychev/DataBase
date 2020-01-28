using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PcRepaire.Data;
using PcRepaire.Models;
using Microsoft.AspNetCore.Authorization;

namespace PcRepaire.Controllers
{
    [Authorize]
    public class SoftWaresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SoftWaresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SoftWares
        public async Task<IActionResult> Index()
        {
            return View(await _context.SoftWares.ToListAsync());
        }

        // GET: SoftWares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softWare = await _context.SoftWares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (softWare == null)
            {
                return NotFound();
            }

            return View(softWare);
        }

        // GET: SoftWares/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SoftWares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Create([Bind("Id,Name")] SoftWare softWare)
        {
            if (ModelState.IsValid)
            {
                _context.Add(softWare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(softWare);
        }

        // GET: SoftWares/Edit/5
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softWare = await _context.SoftWares.FindAsync(id);
            if (softWare == null)
            {
                return NotFound();
            }
            return View(softWare);
        }

        // POST: SoftWares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] SoftWare softWare)
        {
            if (id != softWare.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(softWare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftWareExists(softWare.Id))
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
            return View(softWare);
        }

        // GET: SoftWares/Delete/5
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var softWare = await _context.SoftWares
                .FirstOrDefaultAsync(m => m.Id == id);
            if (softWare == null)
            {
                return NotFound();
            }

            return View(softWare);
        }

        // POST: SoftWares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var softWare = await _context.SoftWares.FindAsync(id);
            _context.SoftWares.Remove(softWare);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftWareExists(int id)
        {
            return _context.SoftWares.Any(e => e.Id == id);
        }
    }
}
