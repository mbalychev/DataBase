using System.ComponentModel;

namespace PcRepaire.Models
{
    public class Pc : EqupmentUsing
    {
        public int HardWareId { get; set; }
        [DisplayName("Hard ware")]
        public HardWare HardWare { get; set; }
    }
}
