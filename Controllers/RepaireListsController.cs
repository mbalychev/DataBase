using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PcRepaire.Data;
using PcRepaire.Models;
using PcRepaire.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Controllers
{
    [Authorize]
    public class RepaireListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RepaireListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RepaireLists
        public async Task<IActionResult> Index(string search, int filterRepairMan, string sort, string message)
        {
            List<ViewRepaire> repaire = await ViewRepaireListAsync();
            //search
            if (!string.IsNullOrEmpty(search)) repaire = repaire.Where(r => r.SerialNumber.Contains(search)).ToList();
            //filter
            if (filterRepairMan != 0) repaire = repaire.Where(r => r.RepaireManId == filterRepairMan).ToList();
            //sort
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

            ViewData["Sort"] = string.IsNullOrEmpty(sort) ? "dateDesc" : "";
            ViewData["RepaireMans"] = FilterRepaireMans(repaire);
            ViewData["FilterRepairMan"] = filterRepairMan;
            ViewData["Search"] = search;
            ViewData["Message"] = message;

            return View(repaire);
        }


        // GET: RepaireLists/Details/5
        public async Task<IActionResult> Details(int? id, string type)
        {
            if (id == null || string.IsNullOrEmpty(type))
            {
                return RedirectToAction(nameof(Index), new { message = "Not found" });
            }


            switch (type)
            {
                case "Pc":
                    {
                        RepairePC repairePC = await _context.RepairePCs.Include(i => i.Pc).Include(r => r.RepaireMan).Select(s => s).FirstOrDefaultAsync(r => r.Id == id);
                        return View("DetailsPc", repairePC);
                    }
                case "Tablet":
                    {
                        RepaireTablet repaireTablet = await _context.RepaireTablets.Include(i => i.Tablet).Include(r => r.RepaireMan).Select(s => s).FirstOrDefaultAsync(r => r.Id == id);
                        return View("DetailsTablets", repaireTablet);
                    }
                default:
                    {
                        return RedirectToAction(nameof(Index), new { message = "Not found" });
                    }
            }

        }

        // GET: RepaireLists/Create
        [Authorize(Roles = "admin")]
        public IActionResult CreatePc()
        {
            ViewData["Equipment"] = new SelectList(_context.Pcs, "Id", "Info");
            ViewData["RepaireMan"] = new SelectList(_context.RepaireMen, "Id", "FullName");
            return View();
        }

        // POST: RepaireLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePc([Bind("Id,EquipmentId,RepaireManId,DateRepaire,SoftWare,HardWare, PcId")] RepairePC repaire)
        {
            repaire.Id = await MaxIdRepaire();

            if (ModelState.IsValid)
            {
                _context.Add(repaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Equipment"] = new SelectList(_context.Pcs, "Id", "Info");
            ViewData["RepaireMan"] = new SelectList(_context.RepaireMen, "Id", "FullName");
            return View("CreatePc");
        }

        // GET: RepaireLists/Create
        [Authorize(Roles = "admin")]
        public IActionResult CreateTablet()
        {
            ViewData["Equipment"] = new SelectList(_context.Tablets, "Id", "Info");
            ViewData["RepaireMan"] = new SelectList(_context.RepaireMen, "Id", "FullName");
            return View();
        }

        // POST: RepaireLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTablet([Bind("Id,EquipmentId,RepaireManId,DateRepaire,SoftWare,TabletId")] RepaireTablet repaire)
        {
            repaire.Id = await MaxIdRepaire();

            if (ModelState.IsValid)
            {
                _context.Add(repaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Equipment"] = new SelectList(_context.Tablets, "Id", "Info");
            ViewData["RepaireMan"] = new SelectList(_context.RepaireMen, "Id", "FullName");
            return View();
        }

        private bool RepaireListsExists(int id)
        {
            return true;
            //return _context.RepaireLists.Any(e => e.Id == id);
        }

        private async Task<List<ViewRepaire>> ViewRepaireListAsync()
        {
            List<ViewRepaire> repaire = new List<ViewRepaire>();
            List<RepairePC> pcs = await _context.RepairePCs.Include(i => i.Pc).Include(i => i.RepaireMan).ToListAsync();
            foreach (RepairePC pc in pcs)
            {
                repaire.Add(new ViewRepaire(pc));
            }
            List<RepaireTablet> tablets = await _context.RepaireTablets.Include(i => i.RepaireMan).Include(i => i.Tablet).ToListAsync();
            foreach (RepaireTablet tablet in tablets)
            {
                repaire.Add(new ViewRepaire(tablet));
            }

            return repaire;
        }

        private List<RepaireMan> FilterRepaireMans(List<ViewRepaire> repaires)
        {
            //filter repaire mans
            int[] idWorker = repaires.GroupBy(g => g.RepaireManId).Select(w => w.Key).ToArray();
            List<RepaireMan> repaireMens = new List<RepaireMan>();
            foreach (int id in idWorker)
                repaireMens.Add(_context.RepaireMen.FirstOrDefault(w => w.Id == id));

            return repaireMens;
        }

        private async Task<int> MaxIdRepaire()
        {
            List<int> ids = await _context.RepairePCs.Select(s => s.Id).ToListAsync();
            ids.AddRange(await _context.RepaireTablets.Select(s => s.Id).ToListAsync());
            return ids.Max() + 1;
        }

    }
}
