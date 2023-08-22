using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityApi
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        
        [ForeignKey(nameof(ProfessorId))]
        public int ProfessorId { get; set; }

        public Professor professor { get; set; }

    }
}
