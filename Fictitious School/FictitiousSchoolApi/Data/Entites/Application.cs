using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Data.Entites
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string CourseHours { get; set; }

        public Company Company { get; set; }

        public List<Participant> Participants { get; set; }
    }
}