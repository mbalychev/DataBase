
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PcRepaire.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Data
{
    public class DbInitializer
    {
        private static ApplicationDbContext _context;
        private static UserManager<IdentityUser> _userManager;
        private static ILogger _logger;
        private static RoleManager<IdentityRole> _roleManager;

        public static async Task DbInitializerStart(IServiceProvider services)
        {
            _context = services.GetRequiredService<ApplicationDbContext>();
            _userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            _roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            _logger = services.GetRequiredService<ILogger<Program>>();
            _context.Database.EnsureCreated();

            await CreateRoles();
            await CreateUsers();
            await CreateWorkers();
            await CreateSoftWare();
            await CreateHardWare();
            await CreatePc();
            await CreateRepairList();
        }

        private static async Task CreateRoles()
        {
            if (!_context.Roles.Any())
            {
                try
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = "admin" });
                    await _roleManager.CreateAsync(new IdentityRole { Name = "user" });
                    _logger.LogInformation("roles... ok");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            else
                _logger.LogInformation("roles... ok");
        }

        private static async Task CreateUsers()
        {
            if (!_context.Users.Any())
            {
                try
                {
                    IdentityUser userAdmin = new IdentityUser { UserName = "admin" };

                    IdentityUser user = new IdentityUser { UserName = "user" };

                    await _userManager.CreateAsync(userAdmin, "qweRT23*");
                    await _userManager.CreateAsync(user, "asdFG23*");
                    await _userManager.AddToRoleAsync(userAdmin, "admin");
                    await _userManager.AddToRoleAsync(user, "user");

                    _logger.LogInformation("users... ok");
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
            else
                _logger.LogInformation("users... ok");
        }
        private static async Task CreateWorkers()
        {
            if (!_context.Workers.Any())
            {
                try
                {
                    var workers = new Worker[]
                            {
                new Worker { Id = 1, FirstName = "Mikhail", LastName = "Balychev"},
                new Worker { Id = 2, FirstName = "Ivan", LastName = "Lisin"},
                new Worker { Id = 3, FirstName = "Petr", LastName = "Harsen"},
                new Worker { Id = 4, FirstName = "Mikhail", LastName = "Vanshin"},
                            };
                    foreach (Worker w in workers) { _context.Workers.Add(w); }
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Worker... ok");

                    using (var tr = _context.Database.BeginTransaction())
                    {
                        tr.Commit();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                }
            }
            else
                _logger.LogInformation("Worker... ok");

        }
        private static async Task CreateSoftWare()
        {
            if (!_context.SoftWares.Any())
            {
                try
                {
                    var softWares = new SoftWare[]
                            {
                new SoftWare { Id = 1, Name = "Windows"},
                new SoftWare { Id = 2, Name = "IOs"},
                new SoftWare { Id = 3, Name = "Linux"}
                            };
                    foreach (SoftWare soft in softWares) { _context.SoftWares.Add(soft); }
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("SoftWare... ok");
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                }
            }
            else
                _logger.LogInformation("SoftWare... ok");

        }
        private static async Task CreateHardWare()
        {
            if (!_context.HardWares.Any())
            {
                try
                {
                    var hardWares = new HardWare[]
                          {
                new HardWare { Id = 1, HardType = "h1"},
                new HardWare { Id = 2, HardType = "h2"},
                new HardWare { Id = 3, HardType = "h3"}
                          };
                    foreach (HardWare hard in hardWares) { _context.HardWares.Add(hard); }
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("HardWare... ok");
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                }
            }
            else
                _logger.LogInformation("HardWares... ok");
        }
        private static async Task CreatePc()
        {
            if (!_context.Pcs.Any())
            {
                try
                {
                    var pcs = new Pc[]
                           {
                new Pc { Id=1, Name = "pc1", HardWareId = 1, SoftWareId = 1 },
                new Pc { Id=2, Name = "pc2", HardWareId = 2, SoftWareId = 1 },
                new Pc { Id=3, Name = "pc3", HardWareId = 3, SoftWareId = 1 },
                new Pc { Id=4, Name = "pc4", HardWareId = 2, SoftWareId = 3 },
                new Pc { Id=5, Name = "pc5", HardWareId = 1, SoftWareId = 1 },
                new Pc { Id=6, Name = "pc6", HardWareId = 3, SoftWareId = 2 },
                new Pc { Id=7, Name = "pc7", HardWareId = 1, SoftWareId = 1 },
                new Pc { Id=8, Name = "pc8", HardWareId = 2, SoftWareId = 2 }
                           };
                    foreach (Pc pc in pcs) { _context.Pcs.Add(pc); }
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Pcs... ok");
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                }
            }
            else
                _logger.LogInformation("Pcs... ok");
        }
        private static async Task CreateRepairList()
        {
            if (!_context.RepairLists.Any())
            {
                try
                {
                    var repairList = new RepairList[]
                          {
                new RepairList { Id = 1, PcId = 1, WorkerId = 1, Date = Convert.ToDateTime("01.01.2020"),  SoftWareRapaired = true, HardWareRapaired = true  },
                new RepairList { Id = 2, PcId = 5, WorkerId = 3, Date = Convert.ToDateTime("03.01.2020"), HardWareRapaired = true, SoftWareRapaired = false  },
                new RepairList { Id = 3, PcId = 7, WorkerId = 4, Date = Convert.ToDateTime("03.01.2020"), HardWareRapaired = true, SoftWareRapaired = false  },
                new RepairList { Id = 4, PcId = 2, WorkerId = 4, Date = Convert.ToDateTime("04.01.2020"), HardWareRapaired = true, SoftWareRapaired = true  },
                new RepairList { Id = 5, PcId = 2, WorkerId = 2, Date = Convert.ToDateTime("07.01.2020"), HardWareRapaired = true, SoftWareRapaired = true },
                new RepairList { Id = 6, PcId = 1, WorkerId = 4, Date = Convert.ToDateTime("07.01.2020"), HardWareRapaired = true, SoftWareRapaired = false  },
                new RepairList { Id = 7, PcId = 4, WorkerId = 2, Date = Convert.ToDateTime("12.01.2020"), HardWareRapaired = false, SoftWareRapaired = true  },
                new RepairList { Id = 8, PcId = 1, WorkerId = 1,  Date = Convert.ToDateTime("12.01.2020"), HardWareRapaired = false, SoftWareRapaired = true  },
                new RepairList { Id = 9, PcId = 2, WorkerId = 2,   Date = Convert.ToDateTime("14.01.2020"), HardWareRapaired = true, SoftWareRapaired = true  },
                new RepairList { Id = 10, PcId = 6, WorkerId = 3,  Date = Convert.ToDateTime("15.01.2020"), HardWareRapaired = false, SoftWareRapaired = true  }
                          };
                    foreach (RepairList repair in repairList) { _context.Add(repair); }
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("RepairList... ok");
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                }
            }
            else
                _logger.LogInformation("RepairList... ok");
        }
    }
}
