using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Dto
{
    public class CompanyDto
    {
        [Required(ErrorMessage = "You must enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}