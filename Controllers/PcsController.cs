using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PcRepaire.Data;
using PcRepaire.Models;

namespace PcRepaire.Controllers
{
    [Authorize]
    public class PcsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PcsController> _logger;

        public PcsController(ApplicationDbContext context, ILogger<PcsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Pcs
        public async Task<IActionResult> Index(string sort, string search, string message)
        {
            ViewData["Sort"] = string.IsNullOrEmpty(sort) ? "ManufactureDesc" : "";
            ViewData["Message"] = message;
            var pcs = _context.Pcs.Include(p => p.EquipUser).Include(p => p.Manufacture).Include(p => p.SoftWare).Include(p => p.HardWare).Select(s => s);

            if (!string.IsNullOrEmpty(search))
                pcs = pcs.Where(n => n.SerialNumber.Contains(search));

            switch (sort)
            {
                case "ManufactureDesc":
                    {
                        pcs = pcs.OrderByDescending(o => o.Manufacture.Name);
                        break;
                    }
                default:
                    {
                        pcs = pcs.OrderBy(o => o.Manufacture.Name);
                        break;
                    }
            }
            return View(await pcs.ToListAsync());
        }

        // GET: Pcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || id == 0)
            {
                ModelState.AddModelError("", "pc not found");
                return RedirectToAction(nameof(Index));
            }

            var pc = await _context.Pcs
                .Include(p => p.EquipUser)
                .Include(p => p.SoftWare)
                .Include(p => p.Manufacture)
                .Include(p => p.HardWare)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pc == null)
            {
                ModelState.AddModelError("", "pc not found");
                return RedirectToAction(nameof(Index));
            }

            return View(pc);
        }

        // GET: Pcs/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["EquipUserId"] = new SelectList(_context.EquipUsers, "Id", "FullName");
            ViewData["SoftWareId"] = new SelectList(_context.SoftWares, "Id", "Name");
            ViewData["HardWareId"] = new SelectList(_context.HardWares, "Id", "HardType");
            ViewData["Manufacture"] = new SelectList(_context.Manufactures, "Id", "Name");
            return View();
        }

        // POST: Pcs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("HardWareId,Id,Model,SerialNumber,SoftWareId,EquipUserId,ManufactureId")] Pc pc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(pc);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Created Pc " + pc.Model + " " + pc.SerialNumber);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "Unable to save changes, Try again");
                    return View(pc);
                }
            }
            else
            {
                ViewData["EquipUserId"] = new SelectList(_context.EquipUsers, "Id", "Discriminator", pc.EquipUserId);
                ViewData["SoftWareId"] = new SelectList(_context.SoftWares, "Id", "Id", pc.SoftWareId);
                ViewData["HardWareId"] = new SelectList(_context.HardWares, "Id", "Id", pc.HardWareId);
                ModelState.AddModelError("", "Unable to save changes, model pc error");
                return View(pc);
            }
        }

        // GET: Pcs/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "pc not found");
                return RedirectToAction(nameof(Index));
            }

            var pc = await _context.Pcs.Include(s=>s.EquipUser).FirstOrDefaultAsync(s=>s.Id == id);
            if (pc == null)
            {
                ModelState.AddModelError("", "pc not found");
                return RedirectToAction(nameof(Index));
            }

            List<SelectListItem> selects = new SelectList(_context.EquipUsers, "Id", "FullName", pc.EquipUserId).ToList();
            selects.Insert(0, (new SelectListItem { Text = "None", Value = "" }));
            
            ViewData["EquipUserId"] = selects;
            ViewData["SoftWareId"] = new SelectList(_context.SoftWares, "Id", "Name", pc.SoftWareId);
            ViewData["HardWareId"] = new SelectList(_context.HardWares, "Id", "HardType", pc.HardWareId);
            ViewData["Manufature"] = new SelectList(_context.Manufactures, "Id", "Name", pc.ManufactureId);
            return View(pc);
        }

        // POST: Pcs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("HardWareId,Id,Model,SerialNumber,SoftWareId,EquipUserId,ManufactureId")] Pc pc)
        {
            if (id != pc.Id)
            {
                ModelState.AddModelError("", "pc not found");
                return RedirectToAction(nameof(Index));
            }

            List<SelectListItem> selects = new SelectList(_context.EquipUsers, "Id", "FullName", pc.EquipUserId).ToList();
            selects.Insert(0, (new SelectListItem { Text = "None", Value = "" }));

            ViewData["EquipUserId"] = selects;
            ViewData["SoftWareId"] = new SelectList(_context.SoftWares, "Id", "Name", pc.SoftWareId);
            ViewData["HardWareId"] = new SelectList(_context.HardWares, "Id", "HardType", pc.HardWareId);
            ViewData["Manufature"] = new SelectList(_context.Manufactures, "Id", "Name", pc.ManufactureId);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pc);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!PcExists(pc.Id))
                    {
                        ModelState.AddModelError("", "Unable to save changes, Try again");
                        _logger.LogError("DbUpdateException on created Pc: " + ex.Message);
                        return View(pc);
                    }
                }
                catch (DbUpdateException ex)
                {
                    _logger.LogError("DbUpdateException on created Pc: " + ex.Message);
                    ModelState.AddModelError("", "Unable to save changes, Try again");
                    return View(pc);
                }

                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipUserId"] = new SelectList(_context.EquipUsers, "Id", "Discriminator", pc.EquipUserId);
            ViewData["SoftWareId"] = new SelectList(_context.SoftWares, "Id", "Id", pc.SoftWareId);
            ViewData["HardWareId"] = new SelectList(_context.HardWares, "Id", "Id", pc.HardWareId);
            ViewData["Manufature"] = new SelectList(_context.Manufactures, "Id", "Name", pc.ManufactureId);
            return View(pc);
        }

        // GET: Pcs/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError("", "pc not found");
                return RedirectToAction(nameof(Index));
            }

            var pc = await _context.Pcs
                .Include(p => p.EquipUser)
                .Include(p => p.Manufacture)
                .Include(p => p.SoftWare)
                .Include(p => p.HardWare)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pc == null)
            {
                ModelState.AddModelError("", "pc not found");
                return RedirectToAction(nameof(Index));
            }

            return View(pc);
        }

        // POST: Pcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pc = await _context.Pcs.FindAsync(id);
            try
            {
                _context.Pcs.Remove(pc);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Deleted Pc " + pc.Model + " " + pc.SerialNumber);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Exception on delete Pc: " + ex.Message);
                ModelState.AddModelError("", "Error on Delete Pc");
                return View(pc);
            }
        }

        private bool PcExists(int id)
        {
            return _context.Pcs.Any(e => e.Id == id);
        }
    }
}
