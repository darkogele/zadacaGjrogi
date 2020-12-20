using SchoolApi.Helpes;
using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Data.Entites
{
    public class Participant : Audit
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must Name")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}