using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Models
{
    public class RepaireTablet : RepaireLists
    {
        public int? TabletId { get; set; }
        public Tablet Tablet { get; set; }
    }
}
