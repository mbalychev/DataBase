using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Models.ViewModels
{
    public class StatRepaires
    {
        [Key]
        public DateTime Date { get; set; }
        [DisplayName("Count repaire list ")]
        public int Count { get; set; }
    }
}
