using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Contracts;
using SchoolApi.Dto;
using System.Collections.Generic;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantsRepository _participantsRepository;
        private readonly IMapper _mapper;
        public ParticipantsController(IParticipantsRepository participantsRepository, IMapper mapper)
        {
            _participantsRepository = participantsRepository;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public IActionResult GetParticipants()
        {
            return Ok(_mapper.Map<IEnumerable<ParticipantsDto>>(_participantsRepository.GetParticipant()));
        }
    }
}