using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Contracts;
using SchoolApi.Dto;
using System.Collections.Generic;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IParticipantsRepository _participantsRepository;
        private readonly IMapper _mapper;

        public CoursesController(ICourseRepository courseRepository, IMapper mapper, IParticipantsRepository participantsRepository)
        {
            _courseRepository = courseRepository;
            _participantsRepository = participantsRepository;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public IActionResult GetCourses()
        {
            var coursesFromRepo = _courseRepository.GetCourses();

            return Ok(_mapper.Map<IEnumerable<CourseDto>>(coursesFromRepo));
        }

        [HttpPost("[action]")]
        public IActionResult SubbmitApplication(ApplicationDto applicationDto)
        {
            _participantsRepository.Addparticipant(applicationDto);
            var responce = _participantsRepository.Save();

            if (!responce)
            {
                return BadRequest("There was error writing the request please try again later");
            }

            return Ok();
        }
    }
}
