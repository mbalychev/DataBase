
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PcRepaire.Models;
using System;
using System.Collections.Generic;
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

            if (!_context.RepaireLists.Any())
            {
                await CreateRoles();
                await CreateUsers();
                await CreateData();
            }
        }

        private static async Task CreateRoles()
        {
            if (!_context.Roles.Any())
            {
                try
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = "admin" });
                    await _roleManager.CreateAsync(new IdentityRole { Name = "user" });
                    _logger.LogInformation("roles... created");
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

                    _logger.LogInformation("users... created");
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

        private static async Task CreateData()
        {
            if (!_context.RepaireLists.Any())
            {
                EquipUser[] equipUsers = Initializer.EquipUsersList.CreateEquipUsersList();
                RepaireMan[] repaireMens = Initializer.RepaireManList.CreateRepaireMen();
                Pc[] pcs = Initializer.PcList.CreatePcLists();
                Tablet[] tablets = Initializer.TabletsList.CreateTabletsList();
                SoftWare[] softWares = Initializer.SoftWareList.CreateSoftWares();
                HardWare[] hardWares = Initializer.HardWareList.CreateHardWares();
                RepaireLists[] repairList = Initializer.RepairList.CreateRepairList();
                Manufacture[] manufactures = Initializer.ManufactureList.CreateManufactures();
                try
                {

                    foreach (Tablet tablet in tablets) { _context.Tablets.Add(tablet); }
                    foreach (Pc pc in pcs) { _context.Pcs.Add(pc); }
                    foreach (SoftWare soft in softWares) { _context.SoftWares.Add(soft); }
                    foreach (HardWare hard in hardWares) { _context.HardWares.Add(hard); }
                    foreach (EquipUser equipUser in equipUsers) { _context.EquipUsers.Add(equipUser); }
                    foreach (RepaireMan repaireMan in repaireMens) { _context.RepaireMen.Add(repaireMan); }
                    foreach (RepaireLists repair in repairList) { _context.RepaireLists.Add(repair); }
                    foreach (Manufacture manufacture in manufactures) { _context.Manufactures.Add(manufacture); }

                    await _context.SaveChangesAsync();
                _logger.LogInformation("DataBase... created");
            }
                catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
            }
        }
            else
                _logger.LogInformation("DataBase... ok");
        }


}
}
