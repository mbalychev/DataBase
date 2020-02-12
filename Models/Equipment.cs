using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{



    public class Equipment
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Model { get; set; }
        [DisplayName("Serial number")]
        public string SerialNumber { get; set; }
        public int SoftWareId { get; set; }
        public SoftWare SoftWare { get; set; }
        public int ManufactureId { get; set; }
        public Manufacture Manufacture { get; set; }
        [DisplayName("Equipment info")]
        public string Info => "Model: " + Model + " Sn: " + SerialNumber;

    }
}

