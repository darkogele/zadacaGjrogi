
using SchoolApi.Data.Entites;
using SchoolApi.Dto;
using System.Collections;

namespace SchoolApi.Contracts
{
    public interface IParticipantsRepository
    {
        IEnumerable GetParticipant();

        Participant GetParticipantById(int id);

        void InsertParticipant(Participant participant);

        void DeleteParticipanty(int id);

        void UpdateParticipant(Participant participant);

        void Addparticipant(ApplicationDto application);

        bool Save();
    }
}