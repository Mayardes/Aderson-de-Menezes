namespace SchoolAdersonDeMenezes.Application.Dtos.ViewModels
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public ParentsViewModel Parents { get; set; }
    }
}
