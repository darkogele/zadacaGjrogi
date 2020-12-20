using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolApi.Helpes
{
    public class Audit
    {
        public Audit()
        {
            CreatedOn = DateTime.Now;
        }

        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}