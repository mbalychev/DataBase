using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PcRepaire.Models;

namespace PcRepaire.Data
{
    public class ApplicationDbContext : IdentityDbContext
        <IdentityUser,
        IdentityRole,
        string,
        IdentityUserClaim<string>,
        IdentityUserRole<string>,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        IdentityUserToken<string>>
    {
        private static ApplicationDbContext _context;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _context = this;
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<HardWare> HardWares { get; set; }
        public DbSet<SoftWare> SoftWares { get; set; }
        public DbSet<RepairList> RepairLists { get; set; }
        public DbSet<Pc> Pcs { get; set; }
        //public DbSet<Enrollment> Enrollments { get; set; }
    }
}
