using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{
    public class RepairList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int PcId { get; set; }
        public int WorkerId { get; set; }
        public bool SoftWare { get; set; }
        public bool HardWare { get; set; }
        public DateTime Date { get; set; }
    }
}
