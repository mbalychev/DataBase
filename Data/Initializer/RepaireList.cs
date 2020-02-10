using PcRepaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Data.Initializer
{
    public class RepaireList
    {
        public static RepaireLists[] CreateRepaire()
        {
            return new RepaireLists[]
            {
                new RepaireLists {  Id = 1, PcId = 1,  RepaireManId = 10, DateRepaire = Convert.ToDateTime("01.01.2020"),  SoftWare = true, HardWare = true  },
                new RepaireLists { Id = 2, PcId = 5, RepaireManId = 13, DateRepaire = Convert.ToDateTime("03.01.2020"), HardWare = true, SoftWare = false  },
                new RepaireLists { Id = 3, PcId = 7, RepaireManId = 15, DateRepaire = Convert.ToDateTime("03.01.2020"), HardWare = true, SoftWare = false  },
                new RepaireLists { Id = 4, PcId = 2, RepaireManId = 10, DateRepaire = Convert.ToDateTime("04.01.2020"), HardWare = true, SoftWare = true  },
                new RepaireLists { Id = 5, PcId = 2, RepaireManId = 11, DateRepaire = Convert.ToDateTime("07.01.2020"), HardWare = true, SoftWare = true },
                new RepaireLists { Id = 6, PcId = 1, RepaireManId = 12, DateRepaire = Convert.ToDateTime("07.01.2020"), HardWare = true, SoftWare = false  },
                new RepaireLists { Id = 7, PcId = 4, RepaireManId = 15, DateRepaire = Convert.ToDateTime("12.01.2020"), HardWare = false, SoftWare = true  },
                new RepaireLists { Id = 8, PcId = 1, RepaireManId = 11,  DateRepaire = Convert.ToDateTime("12.01.2020"), HardWare = false, SoftWare = true  },
                new RepaireLists { Id = 9, PcId = 2, RepaireManId = 10,   DateRepaire = Convert.ToDateTime("14.01.2020"), HardWare = true, SoftWare = true  },
                new RepaireLists { Id = 10, PcId = 6, RepaireManId = 10,  DateRepaire = Convert.ToDateTime("15.01.2020"), HardWare = false, SoftWare = true  },
                new RepaireLists { Id = 11, DateRepaire = Convert.ToDateTime("02.01.2020"), RepaireManId = 10, SoftWare = true, TabletId = 9 },
                new RepaireLists { Id = 12, DateRepaire = Convert.ToDateTime("06.01.2020"), RepaireManId = 13, SoftWare = true, TabletId = 11 },
                new RepaireLists { Id = 13, DateRepaire = Convert.ToDateTime("09.01.2020"), RepaireManId = 11, SoftWare = true, TabletId = 16 },
                new RepaireLists { Id = 14, DateRepaire = Convert.ToDateTime("12.01.2020"), RepaireManId = 11, SoftWare = true, TabletId = 14 },
                new RepaireLists { Id = 15, DateRepaire = Convert.ToDateTime("13.01.2020"), RepaireManId = 14, SoftWare = true, TabletId = 11 },
                new RepaireLists { Id = 16, DateRepaire = Convert.ToDateTime("13.01.2020"), RepaireManId = 15, SoftWare = true, TabletId = 13 }
            };

        }

    }
}
