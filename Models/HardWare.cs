using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PcRepaire.Models
{
    public class HardWare
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [DisplayName("Type of hardware")]
        public string HardType { get; set; }
    }

}
