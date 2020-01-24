using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{
    public class HardWare
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string HardType { get; set; }
    }

}
