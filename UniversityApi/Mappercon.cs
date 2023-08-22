using AutoMapper;

namespace UniversityApi
{
    public class Mappercon : Profile
    {
        public Mappercon()
        {
            CreateMap<Student, BasicStudentDto>().ReverseMap();
            CreateMap<Student, IDstudentDto>().ReverseMap();

            CreateMap<Professor, BasicProfessorDto>().ReverseMap();
        }
    }
}
