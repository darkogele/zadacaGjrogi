using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Dto
{
    public class ParticipantsDto
    {
        [Required(ErrorMessage = "You must Name")]
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}