namespace UniversityApi
{
    public class Professor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public virtual IList<Student> Student { get; set; }
    }
}
