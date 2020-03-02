using System.ComponentModel;

namespace PcRepaire.Models
{
    public class RepairePC : RepaireList
    {
        [DisplayName("Was fix Hardware")]
        public bool HardWare { get; set; }
        public int? PcId { get; set; }
        public Pc Pc { get; set; }
    }
}
