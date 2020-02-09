using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PcRepaire.Data;
using PcRepaire.Models;
using PcRepaire.Models.ViewModels;

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
        public async Task<IActionResult> Index(string search, int filterRepairMan, string sort)
        {
            ViewData["RepaireMans"] = await _context.RepaireMen.ToListAsync();
            ViewData["FilterRepairMan"] = filterRepairMan;
            ViewData["Search"] = search;

            //var repaireList  = _context.RepaireLists.Include(r => r.Equipment).Include(i => i.RepaireMan).Select(s => s).AsNoTracking();
            //List<RepaireLists> repaire = await _context.RepaireLists.Include(r => r.Equipment).Include(i => i.RepaireMan).Include(i=>i.Tablet).Include(i=>i.Pc).ToListAsync();
            List<ViewRepaire> repaire = new List<ViewRepaire>();
            List<RepairePC> pcs = await _context.RepairePCs.Include(i => i.Pc).Include(i=>i.RepaireMan).ToListAsync();
            foreach (RepairePC pc in pcs)
            {
                repaire.Add(new ViewRepaire(pc));
            }
            List<RepaireTablet> tablets = await _context.RepaireTablets.Include(i => i.RepaireMan).Include(i => i.Tablet).ToListAsync();
            foreach (RepaireTablet tablet in tablets)
            {
                repaire.Add(new ViewRepaire(tablet));
            }

            //if (!string.IsNullOrEmpty(search)) repaire = repaire.Where(r => r.Equipment.SerialNumber.Contains(search)).ToList();
            if (!string.IsNullOrEmpty(search)) repaire = repaire.Where(r => r.SerialNumber.Contains(search)).ToList();
            if (filterRepairMan != 0) repaire = repaire.Where(r => r.RepaireManId == filterRepairMan).ToList();

                ViewData["Sort"] = string.IsNullOrEmpty(sort) ? "dateDesc" : "";
                switch (sort)
                {
                    case "dateDesc":
                        {
                            repaire = repaire.OrderByDescending(s => s.DateRepaire).ToList();
                            break;
                        }
                    default:
                        {
                            repaire = repaire.OrderBy(s => s.DateRepaire).ToList();
                            break;
                        }
                }

            return View(repaire);
        }

        // GET: RepaireLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var repaireLists = await _context.RepaireLists
            //    .Include(r => r.Equipment)
            //    .Include(r => r.RepaireMan)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (repaireLists == null)
            //{
            //    return NotFound();
            //}

            return View();
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
            //if (ModelState.IsValid)
            //{
            //    _context.Add(repaireLists);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["EquipmentId"] = new SelectList(_context.Equipments, "Id", "Discriminator", repaireLists.EquipmentId );
            //ViewData["RepaireManId"] = new SelectList(_context.RepaireMen, "Id", "Discriminator", repaireLists.RepaireManId);
            return View();
        }

        // GET: RepaireLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var repaireLists = await _context.RepaireLists.FindAsync(id);
            //if (repaireLists == null)
            //{
            //    return NotFound();
            //}
            //ViewData["EquipmentId"] = new SelectList(_context.Equipments, "Id", "Discriminator", repaireLists.EquipmentId );
            //ViewData["RepaireManId"] = new SelectList(_context.RepaireMen, "Id", "Discriminator", repaireLists.RepaireManId);
            return View();
        }

        // POST: RepaireLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EquipmentId,RepaireManId,DateRepaire,SoftWare,HardWare")] RepaireLists repaireLists)
        {
            //if (id != repaireLists.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(repaireLists);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!RepaireListsExists(repaireLists.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["EquipmentId"] = new SelectList(_context.Equipments, "Id", "Discriminator", repaireLists.EquipmentId );
            //ViewData["RepaireManId"] = new SelectList(_context.RepaireMen, "Id", "Discriminator", repaireLists.RepaireManId);
            return View(repaireLists);
        }

        // GET: RepaireLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var repaireLists = await _context.RepaireLists
            //    .Include(r => r.Equipment)
            //    .Include(r => r.RepaireMan)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (repaireLists == null)
            //{
            //    return NotFound();
            //}

            //return View(repaireLists);
            return View();
        }

        // POST: RepaireLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var repaireLists = await _context.RepaireLists.FindAsync(id);
            //_context.RepaireLists.Remove(repaireLists);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepaireListsExists(int id)
        {
            return true;
            //return _context.RepaireLists.Any(e => e.Id == id);
        }
    }
}
