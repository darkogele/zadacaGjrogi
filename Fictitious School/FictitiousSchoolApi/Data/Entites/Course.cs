using SchoolApi.Helpes;
using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Data.Entites
{
    public class Course : Audit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Dates { get; set; }

        [Required]
        public string Name { get; set; }
    }
}