using SchoolApi.Helpes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SchoolApi.Dto
{
    public class CourseDto : Audit
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("dates")]
        [Required(ErrorMessage = "You must enter Date")]
        public List<string> Dates { get; set; }

        [JsonPropertyName("name")]
        [Required(ErrorMessage = "You must Name number")]
        public string Name { get; set; }
    }
}