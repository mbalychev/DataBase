using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{
    public class SoftWare
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
