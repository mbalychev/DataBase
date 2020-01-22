using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PcRepaire.Models
{
    public class Worker
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [HiddenInput(DisplayValue =false)]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        }
}
