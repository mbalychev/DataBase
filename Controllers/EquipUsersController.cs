using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PcRepaire.Data;
using PcRepaire.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Controllers
{
    [Authorize]
    public class EquipUsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EquipUsersController> _logger;
        public EquipUsersController(ApplicationDbContext context, ILogger<EquipUsersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: EquipUsers
        public async Task<IActionResult> Index(string sort, string search, string message)
        {
            ViewData["Message"] = message;
            ViewData["Sort"] = string.IsNullOrEmpty(sort) ? "LastNameDesc" : "";

            var equipUsers = _context.EquipUsers.Select(s => s);

            if (!string.IsNullOrEmpty(search)) equipUsers = equipUsers.Where(u => u.LastName.Contains(search));

            switch (sort)
            {
                case "LastNameDesc":
                    {
                        equipUsers = equipUsers.OrderByDescending(o => o.LastName);
                        break;
                    }
                default:
                    {
                        equipUsers = equipUsers.OrderBy(o => o.LastName);
                        break;
                    }
            }

            return View(await equipUsers.ToListAsync());
        }

        // GET: EquipUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", new { message = "not found" });
            }

            var equipUser = await _context.EquipUsers.Include(i => i.Tablets).Include(i => i.Pcs)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipUser == null)
            {
                return RedirectToAction("Index", new { message = "not found" });
            }

            return View(equipUser);
        }

        // GET: EquipUsers/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("LastName,FirstName")] EquipUser equipUser)
        {
            int[] ids = _context.Employees.Select(s => s.Id).ToArray();
            equipUser.Id = ids.Max() + 1;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(equipUser);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Created equipment user " + equipUser.FullName);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "create equip user not success, try a later...");
                    _logger.LogError(ex.Message);
                    return View(equipUser);
                }

            }
            ModelState.AddModelError("", "error model");
            return View(equipUser);
        }

        // GET: EquipUsers/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", new { message = "not found" });
            }

            var equipUser = await _context.EquipUsers.FindAsync(id);
            if (equipUser == null)
            {
                return RedirectToAction(nameof(Index), new { message = "not found" });
            }
            return View(equipUser);
        }

        // POST: EquipUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName")] EquipUser equipUser)
        {
            if (id != equipUser.Id)
            {
                return RedirectToAction(nameof(Index), new { message = "not found" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipUser);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipUserExists(equipUser.Id))
                    {
                        ModelState.AddModelError("", "user nor found");
                        return View(equipUser);
                    }
                    else
                    {
                        ModelState.AddModelError("", "eqip user updated error, try a later...");
                        return View(equipUser);
                    }
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", "eqip user updated error, try a later...");
                    _logger.LogError("eqip user updated error " + ex.Message);
                    return View(equipUser);
                }
            }
            return View(equipUser);
        }

        // GET: EquipUsers/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index), new { message = "not found" });
            }

            var equipUser = await _context.EquipUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipUser == null)
            {
                return RedirectToAction(nameof(Index), new { message = "not found" });
            }

            return View(equipUser);
        }

        // POST: EquipUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipUser = await _context.EquipUsers.FindAsync(id);
            try
            {
                _context.EquipUsers.Remove(equipUser);
                await _context.SaveChangesAsync();
                _logger.LogInformation("equip user deleted " + equipUser.LastName);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("delete equip user error " + ex.Message);
                ModelState.AddModelError("", "delete equip user not success, try a later...");
                return View(equipUser);
            }

        }

        private bool EquipUserExists(int id)
        {
            return _context.EquipUsers.Any(e => e.Id == id);
        }
    }
}
