using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PcRepaire.Data;
using PcRepaire.Models;
using System.Linq;
using System.Threading.Tasks;
namespace PcRepaire.Controllers
{
    [Authorize]
    public class TabletsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TabletsController> _logger;

        public TabletsController(ApplicationDbContext context, ILogger<TabletsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Tablets
        public async Task<IActionResult> Index(string search, string sort, string message)
        {
            ViewData["Message"] = message;
            ViewData["Sort"] = string.IsNullOrEmpty(sort) ? "ModelDesc" : "";

            var tablets = _context.Tablets.Include(t => t.EquipUser).Include(t => t.Manufacture).Include(t => t.SoftWare).Select(s => s);

            if (!string.IsNullOrEmpty(search))
                tablets = tablets.Where(t => t.SerialNumber.Contains(search));

            switch (sort)
            {
                case "ModelDesc":
                    tablets = tablets.OrderByDescending(o => o.Model);
                    break;
                default:
                    tablets = tablets.OrderBy(o => o.Model);
                    break;
            }

            return View(await tablets.ToListAsync());
        }

        // GET: Tablets/Details/5
        public async Task<IActionResult> Details(int? id, string link)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index), new { message = "NotFound" });
            }

            var tablet = await _context.Tablets
                .Include(t => t.EquipUser)
                .Include(t => t.Manufacture)
                .Include(t => t.SoftWare)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (tablet == null)
            {
                return RedirectToAction(nameof(Index), new { message = "NotFound" });
            }

            ViewData["BackLink"] = link;
            return View(tablet);
        }

        [Authorize(Roles = "admin")]
        // GET: Tablets/Create
        public IActionResult Create()
        {
            ViewData["EquipUserId"] = new SelectList(_context.EquipUsers, "Id", "FullName");
            ViewData["ManufactureId"] = new SelectList(_context.Manufactures, "Id", "Name");
            ViewData["SoftWareId"] = new SelectList(_context.SoftWares, "Id", "Name");
            return View();
        }

        // POST: Tablets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Model,SerialNumber,SoftWareId,EquipUserId,ManufactureId")] Tablet tablet)
        {
            int[] ids = _context.Tablets.Select(s => s.Id).ToArray();
            tablet.Id = ids.Max() + 1;

            if (ModelState.IsValid)
            {
                _context.Add(tablet);
                await _context.SaveChangesAsync();
                _logger.LogInformation("was created tablets " + tablet.Model + " " + tablet.SerialNumber);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipUserId"] = new SelectList(_context.EquipUsers, "Id", "FullName", tablet.EquipUserId);
            ViewData["ManufactureId"] = new SelectList(_context.Manufactures, "Id", "Name", tablet.ManufactureId);
            ViewData["SoftWareId"] = new SelectList(_context.SoftWares, "Id", "Name", tablet.SoftWareId);
            return View(tablet);
        }

        // GET: Tablets/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index), new { message = "NotFound" });
            }

            var tablet = await _context.Tablets.FindAsync(id);
            if (tablet == null)
            {
                return RedirectToAction(nameof(Index), new { message = "NotFound" });
            }
            ViewData["EquipUserId"] = new SelectList(_context.EquipUsers, "Id", "FullName", tablet.EquipUserId);
            ViewData["ManufactureId"] = new SelectList(_context.Manufactures, "Id", "Name", tablet.ManufactureId);
            ViewData["SoftWareId"] = new SelectList(_context.SoftWares, "Id", "Name", tablet.SoftWareId);
            return View(tablet);
        }

        // POST: Tablets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,SerialNumber,SoftWareId,EquipUserId,ManufactureId")] Tablet tablet)
        {
            if (id != tablet.Id)
            {
                return RedirectToAction(nameof(Index), new { message = "NotFound" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablet);
                    _logger.LogInformation("edit tablets " + tablet.Model + " " + tablet.SerialNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabletExists(tablet.Id))
                    {
                        ModelState.AddModelError("", "please try a later... ");
                        return View(tablet);
                    }
                    else
                    {
                        ModelState.AddModelError("", "please try a later... ");
                        return View(tablet);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipUserId"] = new SelectList(_context.EquipUsers, "Id", "Discriminator", tablet.EquipUserId);
            ViewData["ManufactureId"] = new SelectList(_context.Manufactures, "Id", "Id", tablet.ManufactureId);
            ViewData["SoftWareId"] = new SelectList(_context.SoftWares, "Id", "Id", tablet.SoftWareId);
            return View(tablet);
        }

        // GET: Tablets/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index), new { message = "NotFound" });
            }

            var tablet = await _context.Tablets
                .Include(t => t.EquipUser)
                .Include(t => t.Manufacture)
                .Include(t => t.SoftWare)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tablet == null)
            {
                return RedirectToAction(nameof(Index), new { message = "NotFound" });
            }

            return View(tablet);
        }

        // POST: Tablets/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tablet = await _context.Tablets.FindAsync(id);
            try
            {
                _context.Tablets.Remove(tablet);
                await _context.SaveChangesAsync();
                _logger.LogInformation("deleted tablets " + tablet.Model + " " + tablet.SerialNumber);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                ModelState.AddModelError("", "try a later...");
                return View(tablet);
            }
        }

        private bool TabletExists(int id)
        {
            return _context.Tablets.Any(e => e.Id == id);
        }
    }
}
