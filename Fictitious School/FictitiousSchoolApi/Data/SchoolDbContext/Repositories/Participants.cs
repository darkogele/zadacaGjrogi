using AutoMapper;
using SchoolApi.Contracts;
using SchoolApi.Data.Entites;
using SchoolApi.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApi.Data.SchoolDbContext
{
    public class ParticipantsRepository : IParticipantsRepository
    {
        private readonly SchoolDbContext _context;
        private readonly IMapper _mapper;
        public ParticipantsRepository(SchoolDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void DeleteParticipanty(int id)
        {
            var participantFromDb = _context.Participants.Find(id);
            participantFromDb.DeletedOn = DateTime.Now;
        }

        public IEnumerable GetParticipant()
        {
            return _context.Participants.Where(x => x.DeletedOn == null).ToList();
        }

        public Participant GetParticipantById(int id)
        {
            return _context.Participants.FirstOrDefault(c => c.DeletedOn.Equals(null)
                     && c.Id.Equals(id));
        }

        public void InsertParticipant(Participant participant)
        {
            _context.Participants.Add(participant);
        }

        public bool Save()
        {
           return _context.SaveChanges() > 1;
        }

        public void UpdateParticipant(Participant participant)
        {
            var participantFromDb = _context.Participants.Find(participant.Id);
            participantFromDb.ModifedOn = DateTime.Now;
            participantFromDb.Name = participant.Name;
            participantFromDb.PhoneNumber = participant.PhoneNumber;
            participantFromDb.Email = participant.Email;
        }

        public void Addparticipant(ApplicationDto application)
        {
            // TODO 
            var companyForDb = _mapper.Map<Company>(application.CompanyDto);
            var participantForDb = _mapper.Map<ICollection<Participant>>(application.ParticipantsDto);
            var aplicationForDb = _mapper.Map<Application>(application);
            aplicationForDb.Company = companyForDb;

            _context.Companies.Add(companyForDb);
            _context.Participants.AddRange(participantForDb);
            _context.Applications.Add(aplicationForDb);
        }
    }
}