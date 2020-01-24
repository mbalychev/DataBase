using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{
    public class Pc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int HardWareId { get; set; }
        public int SoftWareId { get; set; }
    }
}
