using SchoolApi.Helpes;
using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Data.Entites
{
    public class Company : Audit
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}