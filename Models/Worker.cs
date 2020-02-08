using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;

namespace PcRepaire.Models
{
    public class Worker
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None), HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        
        public string FullName
        {
            get
            {
                return LastName + " " + FullName;
            }
        }
        public ICollection<RepairList> RepairList { get; set; }
       
    }
}
