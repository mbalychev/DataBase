using System.ComponentModel.DataAnnotations;

namespace PcRepaire.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "RememberMe?")]
        public bool RememberMe { get; set; }
    }
}
