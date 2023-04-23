using SchoolAdersonDeMenezes.Domain.Enums;

namespace SchoolAdersonDeMenezes.Domain.Entities
{
    /// <summary>
    /// Object responsible for modeling Parents.
    /// </summary>
    public class Parents : IEntityBase
    {
        public Guid Id { get; private set; }
        public Guid StudentId { get; private set;}
        public string FullName { get; private set;}
        public string Email {get; private set;}
        public Parent Parent { get; private set;}

        public Parents(Guid studentId, string fullName, Parent parent, string email)
        {
            Id = Guid.NewGuid();
            StudentId = studentId;
            FullName = fullName;
            Parent = parent;
            Email = email;
        }
    }
}
