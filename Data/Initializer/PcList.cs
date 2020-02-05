using PcRepaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Data.Initializer
{
    public class PcList
    {
        public static Pc[] CreatePcLists()
        {
            return new Pc[]
                           {
                new Pc { Id=1, ManufactureId = 1, Model = "tz 89", SerialNumber = "4864160l", HardWareId = 1, SoftWareId = 1, EquipUserId = 1},
                new Pc { Id=2, ManufactureId = 1, Model = "tz 89s", SerialNumber = "098465l",  HardWareId = 2, SoftWareId = 4, EquipUserId = 2},
                new Pc { Id=3, ManufactureId = 4, Model = "trx",  SerialNumber = "rr584333", HardWareId = 3, SoftWareId = 1, EquipUserId = 5 },
                new Pc { Id=4, ManufactureId = 4, Model = "trxS",  SerialNumber = "dfs59053", HardWareId = 2, SoftWareId = 2, EquipUserId = 1 },
                new Pc { Id=5, ManufactureId = 4, Model = "mi322",  SerialNumber = "dfs5545", HardWareId = 1, SoftWareId = 5, EquipUserId = 6 },
                new Pc { Id=6, ManufactureId = 2, Model = "hp10",  SerialNumber = "000045", HardWareId = 3, SoftWareId = 2, EquipUserId = 8 },
                new Pc { Id=7, ManufactureId = 2, Model = "hp10",  SerialNumber = "000046", HardWareId = 1, SoftWareId = 1, EquipUserId = 3 },
                new Pc { Id=8, ManufactureId = 1, Model = "tz 89-1",  SerialNumber = "558643l", HardWareId = 2, SoftWareId = 4 }
                           };
        }
    }
}
