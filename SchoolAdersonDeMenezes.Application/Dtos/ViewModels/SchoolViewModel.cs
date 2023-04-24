using SchoolAdersonDeMenezes.Domain.Entities;
using SchoolAdersonDeMenezes.Domain.Enums;
using SchoolAdersonDeMenezes.Domain.ValueObjects;

namespace SchoolAdersonDeMenezes.Application.Dtos.ViewModels
{
    public class SchoolViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TypePublicEducation { get; set; }
        public AddressViewModel Address { get; set; }
        public List<StudentViewModel> Students { get; set; }
        public string Status { get; set; }

        public School ToEntity()
        {
            TypePublicEducation education;
            Enum.TryParse<TypePublicEducation>(TypePublicEducation, true, out education);

            return new School(Name, education, 
                new Address(Address.Street, Address.City, Address.State, Address.Number),
                Students.Select(x => new Student(x.FullName, x.Email, new Parents(x.Parents.Id, x.Parents?.FullName, x.Parents.Parent, x.Parents?.Email))).ToList());
        }
    }
}
