using System.Collections.Generic;

namespace SchoolApi.Dto
{
    public class ApplicationDto
    {
        public int CourseId { get; set; }
        public string CourseHours { get; set; }

        public CompanyDto CompanyDto { get; set; }

        public List<ParticipantsDto> ParticipantsDto { get; set; }
    }
}