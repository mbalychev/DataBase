using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{
    public class RepaireList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int RepaireManId { get; set; }
        [DisplayName("Repaire man")]
        public RepaireMan RepaireMan { get; set; }
        [DisplayName("Date of repaire")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateRepaire { get; set; }
        [DisplayName("Was fix Software")]
        public bool SoftWare { get; set; }


    }
}
