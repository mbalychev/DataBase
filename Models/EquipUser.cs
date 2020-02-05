using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PcRepaire.Models;
namespace PcRepaire.Models
{
    public class EquipUser : Employee
    {
        //public int? EquipmentID { get; set; }
        public ICollection<Equipment> Equipment { get; set; }
    }
}
