using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Models
{
    public class RepairList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int PcId { get; set; }
        public int WorkerId { get; set; }
        public bool SoftWare {get;set;}
        public bool HardWare { get; set; }
        public DateTime Date { get; set; }
    }
}
