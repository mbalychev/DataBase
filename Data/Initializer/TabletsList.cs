using PcRepaire.Models;

namespace PcRepaire.Data.Initializer
{
    public class TabletsList
    {
        public static Tablet[] CreateTabletsList()
        {
            return new Tablet[]
            {
                 new Tablet { Id=17, ManufactureId = 3, Model = "IPad 4", SerialNumber = "00056", SoftWareId = 1, EquipUserId = 1},
                new Tablet { Id=18, ManufactureId = 3, Model = "IPad 4", SerialNumber = "00058", SoftWareId = 1, EquipUserId = 4},
                new Tablet { Id=19, ManufactureId = 3, Model = "IPad 4",  SerialNumber = "00059", SoftWareId = 1, EquipUserId = 3},
                new Tablet { Id=20, ManufactureId = 5, Model = "Galaxy Tab S5e",  SerialNumber = "fr456", SoftWareId = 3, EquipUserId = 6 },
                new Tablet { Id=21, ManufactureId = 5, Model = "Galaxy Tab S5e",  SerialNumber = "fr453", SoftWareId = 1, EquipUserId = 7 },
                new Tablet { Id=22, ManufactureId = 5, Model = "Galaxy Tab S5e",  SerialNumber = "fr654", SoftWareId = 2, EquipUserId = 9 },
                new Tablet { Id=23, ManufactureId = 5, Model = "Galaxy Tab S5e",  SerialNumber = "fr656", SoftWareId = 1 },
                new Tablet { Id=24, ManufactureId = 5, Model = "Galaxy Tab S5e",  SerialNumber = "fr333", SoftWareId = 2 }
            };
        }
    }
}
