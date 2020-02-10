using PcRepaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Data.Initializer
{
    public class TabletsList
    {
        public static Tablet[] CreateTabletsList()
        {
            return new Tablet[]
            {
                 new Tablet { Id=9, ManufactureId = 3, Model = "IPad 4", SerialNumber = "00056", SoftWareId = 1, EquipUserId = 1},
                new Tablet { Id=10, ManufactureId = 3, Model = "IPad 4", SerialNumber = "00058", SoftWareId = 1, EquipUserId = 4},
                new Tablet { Id=11, ManufactureId = 3, Model = "IPad 4",  SerialNumber = "00059", SoftWareId = 1, EquipUserId = 3},
                new Tablet { Id=12, ManufactureId = 5, Model = "Galaxy Tab S5e",  SerialNumber = "fr456", SoftWareId = 3, EquipUserId = 6 },
                new Tablet { Id=13, ManufactureId = 5, Model = "Galaxy Tab S5e",  SerialNumber = "fr453", SoftWareId = 1, EquipUserId = 7 },
                new Tablet { Id=14, ManufactureId = 5, Model = "Galaxy Tab S5e",  SerialNumber = "fr654", SoftWareId = 2, EquipUserId = 9 },
                new Tablet { Id=15, ManufactureId = 5, Model = "Galaxy Tab S5e",  SerialNumber = "fr656", SoftWareId = 1 },
                new Tablet { Id=16, ManufactureId = 5, Model = "Galaxy Tab S5e",  SerialNumber = "fr333", SoftWareId = 2 }
            };
        }
    }
}
