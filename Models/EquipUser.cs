using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using PcRepaire.Models;
namespace PcRepaire.Models
{
    public class EquipUser : Employee
    {
        //public int? EquipmentID { get; set; }
        [DisplayName("Use equipment")]
        public ICollection<Pc> Pcs { get; set; }
        public ICollection<Tablet> Tablets { get; set; }
    }
}
