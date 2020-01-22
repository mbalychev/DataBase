using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PcRepaire.Models;

namespace PcRepaire.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILogger<ApplicationDbContext> logger)
            : base(options)
        {

        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<HardWare> HardWares { get; set; }
        public DbSet<SoftWare> SoftWares { get; set; }
        public DbSet<RepairList> RepairLists { get; set; }
        public DbSet<Pc> Pcs { get; set; }
    }
}
