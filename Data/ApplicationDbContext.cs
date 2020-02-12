using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PcRepaire.Models;

namespace PcRepaire.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string, IdentityUserClaim<string>,
        IdentityUserRole<string>, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private static ApplicationDbContext _context;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _context = this;
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<HardWare> HardWares { get; set; }
        public DbSet<SoftWare> SoftWares { get; set; }
        public DbSet<RepairePC> RepairePCs { get; set; }
        public DbSet<RepaireTablet> RepaireTablets { get; set; }
        public DbSet<Pc> Pcs { get; set; }
        public DbSet<Tablet> Tablets { get; set; }
        public DbSet<RepaireMan> RepaireMen { get; set; }
        public DbSet<EquipUser> EquipUsers { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }

    }
}
