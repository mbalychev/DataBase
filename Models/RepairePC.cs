using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Models
{
    public class RepairePC : RepaireLists
    {
        [DisplayName("Was fix Hardware")]
        public bool HardWare { get; set; }
        public int? PcId { get; set; }
        public Pc Pc { get; set; }
    }
}
