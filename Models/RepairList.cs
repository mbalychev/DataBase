using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{
    public class RepairList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int PcId { get; set; }
        public int WorkerId { get; set; }
        public bool SoftWareRapaired { get; set; }
        public bool HardWareRapaired { get; set; }
        [DisplayName("Date of repaire")]
        public DateTime Date { get; set; }
        
        public Worker Worker { get; set; }
        public Pc Pc { get; set; }
        public SoftWare SoftWare { get; set; }
        public HardWare HardWare { get; set; }
    }
}
