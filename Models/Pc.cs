using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{
    public class Pc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [DisplayName("Computer name")]
        public string Name { get; set; }
        public int HardWareId { get; set; }
        public int SoftWareId { get; set; }

        public HardWare HardWare { get; set; }
        public SoftWare SoftWare { get; set; }
    }
}
