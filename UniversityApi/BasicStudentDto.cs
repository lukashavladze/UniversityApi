using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace UniversityApi
{
    public class BasicStudentDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int ProfessorId { get; set; }
    }
}
