using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{
    public class Worker
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
