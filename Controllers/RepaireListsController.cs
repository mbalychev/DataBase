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
    public class RepaireListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepaireListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RepaireLists
        public async Task<IActionResult> Index(string search, int filterRepairMan)
        {
            ViewData["RepaireMans"] = await _context.RepaireMen.ToListAsync();
            ViewData["FilterRepairMan"] = filterRepairMan;
            ViewData["Search"] = search;



            var applicationDbContext = _context.RepaireLists.Include(r => r.Equipment).Include(i=>i.RepaireMan).Select(s=>s).AsNoTracking();
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RepaireLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repaireLists = await _context.RepaireLists
                .Include(r => r.Equipment)
                .Include(r => r.RepaireMan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repaireLists == null)
            {
                return NotFound();
            }

            return View(repaireLists);
        }

        // GET: RepaireLists/Create
        public IActionResult Create()
        {
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "Id", "Discriminator");
            ViewData["RepaireManId"] = new SelectList(_context.RepaireMen, "Id", "Discriminator");
            return View();
        }

        // POST: RepaireLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EquipmentId,RepaireManId,DateRepaire,SoftWare,HardWare")] RepaireLists repaireLists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repaireLists);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "Id", "Discriminator", repaireLists.EquipmentId );
            ViewData["RepaireManId"] = new SelectList(_context.RepaireMen, "Id", "Discriminator", repaireLists.RepaireManId);
            return View(repaireLists);
        }

        // GET: RepaireLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repaireLists = await _context.RepaireLists.FindAsync(id);
            if (repaireLists == null)
            {
                return NotFound();
            }
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "Id", "Discriminator", repaireLists.EquipmentId );
            ViewData["RepaireManId"] = new SelectList(_context.RepaireMen, "Id", "Discriminator", repaireLists.RepaireManId);
            return View(repaireLists);
        }

        // POST: RepaireLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EquipmentId,RepaireManId,DateRepaire,SoftWare,HardWare")] RepaireLists repaireLists)
        {
            if (id != repaireLists.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repaireLists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepaireListsExists(repaireLists.Id))
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
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "Id", "Discriminator", repaireLists.EquipmentId );
            ViewData["RepaireManId"] = new SelectList(_context.RepaireMen, "Id", "Discriminator", repaireLists.RepaireManId);
            return View(repaireLists);
        }

        // GET: RepaireLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repaireLists = await _context.RepaireLists
                .Include(r => r.Equipment)
                .Include(r => r.RepaireMan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repaireLists == null)
            {
                return NotFound();
            }

            return View(repaireLists);
        }

        // POST: RepaireLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repaireLists = await _context.RepaireLists.FindAsync(id);
            _context.RepaireLists.Remove(repaireLists);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepaireListsExists(int id)
        {
            return _context.RepaireLists.Any(e => e.Id == id);
        }
    }
}
