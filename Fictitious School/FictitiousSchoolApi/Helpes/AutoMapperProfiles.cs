using AutoMapper;
using SchoolApi.Data.Entites;
using SchoolApi.Dto;

namespace SchoolApi.Helpes
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<ApplicationDto, Application>().ReverseMap();
            CreateMap<ParticipantsDto, Participant>().ReverseMap();
            CreateMap<CompanyDto, Company>().ReverseMap();


            // IDEA for return 
            //char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            //CreateMap<Course, CourseDto>().
            //    ForMember(x => x.Dates, opt => opt.MapFrom(src => src.Dates.Split(delimiterChars)));
        }
      
    }
}