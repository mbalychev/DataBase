using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{
    public class Enrollment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public int WorkerId { get; set; }
        public int RepairListId { get; set; }

        public ICollection<Worker> Workers { get; set; }
        public ICollection<RepairList> RepairLists { get; set; }
    }
}
