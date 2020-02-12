using System.Collections.Generic;
using System.ComponentModel;

namespace PcRepaire.Models
{
    public class RepaireMan : Employee
    {
        [DisplayName("Repaire list")]
        public ICollection<RepaireLists> RepairList { get; set; }
    }
}
