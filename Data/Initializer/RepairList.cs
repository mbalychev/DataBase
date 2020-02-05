using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Data.Initializer
{
    public class RepairList
    {
        public static Models.RepaireLists[] CreateRepairList()
        {
            return new Models.RepaireLists[]
                          {
                new Models.RepaireLists { Id = 1, EquipmentId = 1, RepaireManId = 1, DateRepaire = Convert.ToDateTime("01.01.2020"),  SoftWare = true, HardWare = true  },
                new Models.RepaireLists { Id = 2, EquipmentId = 5, RepaireManId = 3, DateRepaire = Convert.ToDateTime("03.01.2020"), HardWare = true, SoftWare = false  },
                new Models.RepaireLists { Id = 3, EquipmentId = 7, RepaireManId = 4, DateRepaire = Convert.ToDateTime("03.01.2020"), HardWare = true, SoftWare = false  },
                new Models.RepaireLists { Id = 4, EquipmentId = 2, RepaireManId = 4, DateRepaire = Convert.ToDateTime("04.01.2020"), HardWare = true, SoftWare = true  },
                new Models.RepaireLists { Id = 5, EquipmentId = 2, RepaireManId = 2, DateRepaire = Convert.ToDateTime("07.01.2020"), HardWare = true, SoftWare = true },
                new Models.RepaireLists { Id = 6, EquipmentId = 1, RepaireManId = 4, DateRepaire = Convert.ToDateTime("07.01.2020"), HardWare = true, SoftWare = false  },
                new Models.RepaireLists { Id = 7, EquipmentId = 4, RepaireManId = 2, DateRepaire = Convert.ToDateTime("12.01.2020"), HardWare = false, SoftWare = true  },
                new Models.RepaireLists { Id = 8, EquipmentId = 1, RepaireManId = 1,  DateRepaire = Convert.ToDateTime("12.01.2020"), HardWare = false, SoftWare = true  },
                new Models.RepaireLists { Id = 9, EquipmentId = 2, RepaireManId = 2,   DateRepaire = Convert.ToDateTime("14.01.2020"), HardWare = true, SoftWare = true  },
                new Models.RepaireLists { Id = 10, EquipmentId = 6, RepaireManId = 3,  DateRepaire = Convert.ToDateTime("15.01.2020"), HardWare = false, SoftWare = true  }
                          };
        }
    }
}
