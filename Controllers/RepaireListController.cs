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
using Microsoft.Extensions.Logging;

namespace PcRepaire.Controllers
{
    [Authorize]
    public class RepaireListController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RepairList> _logger;

        public RepaireListController(ApplicationDbContext context, ILogger<RepairList> logger )
        {
            _context = context;
            _logger = logger;
        }

        // GET: RepairLists
        public async Task<IActionResult> Index(string sort, string currentFilter, string search, int? pageNumber)
        {
            ViewData["CurrentSort"] = sort;
            ViewData["Name"] = sort == "Name_desc" ? "Name_asc" : "Name_desc";
            ViewData["Date"] = string.IsNullOrEmpty(sort) ? "Date_desc" : "";
            ViewData["Search"] = search;

            var repairLists =  _context.RepairLists.Include(r => r.Pc).Include(w => w.Worker).Select(s=>s);

            if (search != null)
                pageNumber = 1;
            else
                search = currentFilter;

            ViewData["CurrentFilter"] = search;

            if (!String.IsNullOrEmpty(search))
            {
                repairLists = repairLists.Where(r => r.Worker.LastName.Contains(search));
            }

            switch (sort)
            {
                case "Name_desc":
                    repairLists = repairLists.OrderByDescending(r => r.Worker.LastName);
                    break;
                case "Name_asc":
                    repairLists = repairLists.OrderBy(r => r.Worker.LastName);
                    break;
                case "Date_desc":
                    repairLists = repairLists.OrderByDescending(r => r.Date);
                    break;
                default:
                    repairLists = repairLists.OrderBy(r => r.Date);
                    break;
            }
            int pageSize = 3;
            return View(await PagesList<RepairList>.CreateAsync(repairLists.AsNoTracking().Include(r => r.Pc).Include(w => w.Worker), pageNumber ?? 1, pageSize));
        }

        // GET: RepairLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairList = await _context.RepairLists
                .Include(r => r.Pc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairList == null)
            {
                return NotFound();
            }

            return View(repairList);
        }

        // GET: RepairLists/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            ViewData["PcId"] = new SelectList(_context.Pcs, "Id", "Id");
            return View();
        }

        // POST: RepairLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PcId,WorkerId,SoftWare,HardWare,Date")] RepairList repairList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repairList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PcId"] = new SelectList(_context.Pcs, "Id", "Id", repairList.PcId);
            return View(repairList);
        }

        // GET: RepairLists/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairList = await _context.RepairLists.FindAsync(id);
            if (repairList == null)
            {
                return NotFound();
            }
            ViewData["PcId"] = new SelectList(_context.Pcs, "Id", "Id", repairList.PcId);
            return View(repairList);
        }

        // POST: RepairLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PcId,WorkerId,SoftWare,HardWare,Date")] RepairList repairList)
        {
            if (id != repairList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repairList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairListExists(repairList.Id))
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
            ViewData["PcId"] = new SelectList(_context.Pcs, "Id", "Id", repairList.PcId);
            return View(repairList);
        }

        // GET: RepairLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairList = await _context.RepairLists
                .Include(r => r.Pc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairList == null)
            {
                return NotFound();
            }

            return View(repairList);
        }

        // POST: RepairLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repairList = await _context.RepairLists.FindAsync(id);
            _context.RepairLists.Remove(repairList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairListExists(int id)
        {
            return _context.RepairLists.Any(e => e.Id == id);
        }
    }
}
