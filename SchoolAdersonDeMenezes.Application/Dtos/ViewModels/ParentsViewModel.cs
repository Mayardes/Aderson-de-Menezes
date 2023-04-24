using SchoolAdersonDeMenezes.Domain.Enums;

namespace SchoolAdersonDeMenezes.Application.Dtos.ViewModels
{
    public class ParentsViewModel
    {
        public ParentsViewModel(Guid id, Guid studentId, string fullName, string email, Parent parent)
        {
            Id = id;
            StudentId = studentId;
            FullName = fullName;
            Email = email;
            Parent = parent;
        }

        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Parent Parent { get; set; }
    }
}
