using SchoolAdersonDeMenezes.Domain.Events;

namespace SchoolAdersonDeMenezes.Domain.Entities
{
    /// <summary>
    /// Object responsible for modeling Student.
    /// </summary>
    public class Student : IEntityBase
    {
        public Guid Id { get; private set;}
        public string FullName { get; private set;}
        public string Email { get; private set;}
        public Parents Parents { get; private set;}

        public Student(string fullName, string email, Parents parent)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            Parents = parent;
        }
    }
}
