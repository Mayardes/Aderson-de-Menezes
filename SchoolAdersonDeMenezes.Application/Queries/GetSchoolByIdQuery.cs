using MediatR;
using SchoolAdersonDeMenezes.Application.Dtos.ViewModels;
using SchoolAdersonDeMenezes.Domain.Entities;

namespace SchoolAdersonDeMenezes.Application.Queries
{
    public class GetSchoolByIdQuery : IRequest<SchoolViewModel>
    {
        public Guid Id { get; set; }

        public SchoolViewModel FromEntity(School school)
        {
            return new SchoolViewModel
            {
                Id = school.Id,
                Name = school.Name,
                Address = new AddressViewModel()
                {
                    Street = school.Address.Street,
                    City = school.Address.City,
                    State = school.Address.State,
                    Number = school.Address.Number
                },
                Status = school.Status.ToString(),
                Students = school.Students.Select(x => new StudentViewModel()
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Email = x.Email,
                    Parents = new ParentsViewModel(x.Parents.Id, x.Parents.StudentId, x.Parents.FullName, x.Parents.Email, x.Parents.Parent)

                }).ToList()
            };
        }
    }
}