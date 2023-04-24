using MediatR;
using SchoolAdersonDeMenezes.Application.Dtos.InputModels;
using SchoolAdersonDeMenezes.Domain.Entities;
using SchoolAdersonDeMenezes.Domain.Enums;
using SchoolAdersonDeMenezes.Domain.ValueObjects;

namespace SchoolAdersonDeMenezes.Application.Commands
{
    public class AddSchoolCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public TypePublicEducation TypePublicEducation { get; set; }
        public AddressInputModel Address { get; set; }
        public List<StudentInputModel> Students { get; set; }

        public School ToEntity()
        {
            return new School(Name, TypePublicEducation,
                new Address(Address.Street, Address.City, Address.State, Address.Number),
                Students.Select(x => new Student(x.FullName, x.Email, new Parents(x.Parents.StudentId, x.Parents.FullName, x.Parents.Parent, x.Parents.Email))).ToList());
        }
    }
}
