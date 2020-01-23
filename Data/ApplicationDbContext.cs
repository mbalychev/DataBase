using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
        //static ApplicationDbContext _context;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          //  _context = this;
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<HardWare> HardWares { get; set; }
        public DbSet<SoftWare> SoftWares { get; set; }
        public DbSet<RepairList> RepairLists { get; set; }
        public DbSet<Pc> Pcs { get; set; }
    }
}
