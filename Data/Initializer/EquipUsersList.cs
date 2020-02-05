using PcRepaire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Data.Initializer
{
    public class EquipUsersList
    {
        public static EquipUser[] CreateEquipUsersList()
        {
            return new EquipUser[]
            {
                new EquipUser { Id = 1, FirstName = "Mikhail", LastName = "Balychev" },
                new EquipUser { Id = 2, FirstName = "Ivan", LastName = "Lisin"},
                new EquipUser { Id = 3, FirstName = "Petr", LastName = "Harsen"},
                new EquipUser { Id = 4, FirstName = "Mikhail", LastName = "Vanshin"},
                new EquipUser { Id = 5, FirstName = "Ivan", LastName = "Feodosev"},
                new EquipUser { Id = 6, FirstName = "Igor", LastName = "Lashpin"},
                new EquipUser { Id = 7, FirstName = "Egor", LastName = "Feodosev"},
                new EquipUser { Id = 8, FirstName = "Vasiliy", LastName = "Ihnatov"},
                new EquipUser { Id = 9, FirstName = "Maksim", LastName = "Silin"}
            };
        }
    }
}
