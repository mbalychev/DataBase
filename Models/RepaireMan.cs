using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PcRepaire.Models
{
    public class RepaireMan : Employee
    {
        [DisplayName("Repaire lists")]
        public ICollection<RepaireList> RepaireLists { get; set; }
        [DisplayName("Experience index")]
        public int Experience
        {
            get
            {
                return RepaireLists.Count();
            }
        }
    }
}
