using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Models
{
    public class RepaireMan : Employee
    {
        [DisplayName("Repaire list")]
        public ICollection<RepaireLists> RepairList { get; set; }
    }
}
