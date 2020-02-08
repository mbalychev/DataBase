using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{
    public class RepairList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int PcId { get; set; }
        public int WorkerId { get; set; }
        [Display(Name = "Soft bag fix")]
        public bool SoftWareRapaired { get; set; }
        [Display(Name = "Hard replace")]
        public bool HardWareRapaired { get; set; }
        [Display(Name = "Date of repaire"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd.mm.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        
        public Worker Worker { get; set; }
        public Pc Pc { get; set; }
        public SoftWare SoftWare { get; set; }
        public HardWare HardWare { get; set; }
    }
}
