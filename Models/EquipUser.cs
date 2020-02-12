using System.Collections.Generic;
using System.ComponentModel;
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
