using PcRepaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Data.Initializer
{
    public class RepairPcsList
    {
        public static RepairePC[] CreateRepairPcs()
        {
            return new RepairePC[]
            {
                    new RepairePC {  Id = 1, PcId = 1,  RepaireManId = 10, DateRepaire = Convert.ToDateTime("01.01.2020"),  SoftWare = true, HardWare = true  },
                    new RepairePC { Id = 2, PcId = 5, RepaireManId = 13, DateRepaire = Convert.ToDateTime("03.01.2020"), HardWare = true, SoftWare = false  },
                    new RepairePC { Id = 3, PcId = 7, RepaireManId = 15, DateRepaire = Convert.ToDateTime("03.01.2020"), HardWare = true, SoftWare = false  },
                    new RepairePC { Id = 4, PcId = 2, RepaireManId = 10, DateRepaire = Convert.ToDateTime("04.01.2020"), HardWare = true, SoftWare = true  },
                    new RepairePC { Id = 5, PcId = 2, RepaireManId = 11, DateRepaire = Convert.ToDateTime("07.01.2020"), HardWare = true, SoftWare = true },
                    new RepairePC { Id = 6, PcId = 1, RepaireManId = 12, DateRepaire = Convert.ToDateTime("07.01.2020"), HardWare = true, SoftWare = false  },
                    new RepairePC { Id = 7, PcId = 4, RepaireManId = 15, DateRepaire = Convert.ToDateTime("12.01.2020"), HardWare = false, SoftWare = true  },
                    new RepairePC { Id = 8, PcId = 1, RepaireManId = 11,  DateRepaire = Convert.ToDateTime("12.01.2020"), HardWare = false, SoftWare = true  },
                    new RepairePC { Id = 9, PcId = 2, RepaireManId = 10,   DateRepaire = Convert.ToDateTime("14.01.2020"), HardWare = true, SoftWare = true  },
                    new RepairePC { Id = 10, PcId = 6, RepaireManId = 10,  DateRepaire = Convert.ToDateTime("15.01.2020"), HardWare = false, SoftWare = true  }
            };

        }

    }
}
