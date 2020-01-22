
using PcRepaire.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Data
{
    public class DbInitializer
    {
        public static bool DbInitializerStart (ApplicationDbContext context)
        {
            
            context.Database.EnsureCreated();
            if (context.Workers.Any())
            {
                
                return true;
            }
            else
            {
                try
                {
                    var workers = new Worker[]
                    {
                new Worker { Id = 1, FirstName = "Mikhail", LastName = "Balyche"},
                new Worker { Id = 2, FirstName = "Ivan", LastName = "Lisin"},
                new Worker { Id = 3, FirstName = "Petr", LastName = "Harsen"},
                new Worker { Id = 4, FirstName = "Mikhail", LastName = "Vanshin"},
                    };
                    foreach (Worker w in workers) { context.Workers.Add(w); }

                    var softWares = new SoftWare[]
                    {
                new SoftWare { Id = 1, Name = "Windows"},
                new SoftWare { Id = 2, Name = "IOs"},
                new SoftWare { Id = 3, Name = "Linux"}
                    };
                    foreach (SoftWare soft in softWares) { context.SoftWares.Add(soft); }

                    var hardWares = new HardWare[]
                    {
                new HardWare { Id = 1, HardType = "h1"},
                new HardWare { Id = 2, HardType = "h2"},
                new HardWare { Id = 3, HardType = "h3"}
                    };
                    foreach (HardWare hard in hardWares) { context.HardWares.Add(hard); }

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
                    foreach (Pc pc in pcs) { context.Pcs.Add(pc); }

                    var repairList = new RepairList[]
                    {
                new RepairList { Id = 1, PcId = 1, WorkerId = 1, Date = Convert.ToDateTime("01.01.2020"), HardWare = true, SoftWare = true  },
                new RepairList { Id = 2, PcId = 5, WorkerId = 3, Date = Convert.ToDateTime("03.01.2020"), HardWare = true, SoftWare = false  },
                new RepairList { Id = 3, PcId = 7, WorkerId = 4, Date = Convert.ToDateTime("03.01.2020"), HardWare = false, SoftWare = false  },
                new RepairList { Id = 4, PcId = 2, WorkerId = 4, Date = Convert.ToDateTime("04.01.2020"), HardWare = true, SoftWare = true  },
                new RepairList { Id = 5, PcId = 2, WorkerId = 2, Date = Convert.ToDateTime("07.01.2020"), HardWare = true, SoftWare = true },
                new RepairList { Id = 6, PcId = 1, WorkerId = 4, Date = Convert.ToDateTime("07.01.2020"), HardWare = true, SoftWare = false  },
                new RepairList { Id = 7, PcId = 4, WorkerId = 2, Date = Convert.ToDateTime("12.01.2020"), HardWare = false, SoftWare = false  },
                new RepairList { Id = 8, PcId = 1, WorkerId = 1,  Date = Convert.ToDateTime("12.01.2020"), HardWare = false, SoftWare = true  },
                new RepairList { Id = 9, PcId = 2, WorkerId = 2,   Date = Convert.ToDateTime("14.01.2020"), HardWare = true, SoftWare = true  },
                new RepairList { Id = 10, PcId = 6, WorkerId = 3,  Date = Convert.ToDateTime("15.01.2020"), HardWare = false, SoftWare = true  }
                    };
                    foreach (RepairList repair in repairList) { context.Add(repair); }
                    context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }
    }
}
