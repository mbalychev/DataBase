using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{
    public class Pc :Equipment
    {
        public string Type => "Personal computer";
        //public Employee Employee { get; set; }
        public int HardWareId { get; set; }
        [DisplayName("Hard ware")]
        public HardWare HardWare { get; set; }
    }
}
