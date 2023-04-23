using SchoolAdersonDeMenezes.Domain.Entities;

namespace SchoolAdersonDeMenezes.Domain.Events
{
    /// <summary>
    /// Event responsible for launch values StudentCreated.
    /// </summary>
    public class StudentCreated : IEntityBase, IDomainEvent
    {
        public Guid Id { get; private set;}
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public Parents Parents { get; private set; }

        public StudentCreated(Guid id, string fullName, string email, Parents parents)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            Parents = parents;
        }
    }
}
