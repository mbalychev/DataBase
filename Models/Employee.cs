using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcRepaire.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Full name")]
        public string FullName => FirstName + " " + LastName;


    }
}
