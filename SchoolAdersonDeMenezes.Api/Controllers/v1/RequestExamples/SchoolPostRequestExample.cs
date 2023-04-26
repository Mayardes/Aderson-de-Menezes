using Bogus;
using SchoolAdersonDeMenezes.Application.Commands;
using Swashbuckle.AspNetCore.Filters;
using SchoolAdersonDeMenezes.Application.Dtos.InputModels;
using SchoolAdersonDeMenezes.Domain.Enums;

namespace SchoolAdersonDeMenezes.Api.Controllers.v1.RequestExamples
{
    public class SchoolPostRequestExample : IMultipleExamplesProvider<AddSchoolCommand>
    {
        public IEnumerable<SwaggerExample<AddSchoolCommand>> GetExamples()
        {
            var faker = new Faker("pt_BR");
            Guid id = Guid.NewGuid();

            yield return new SwaggerExample<AddSchoolCommand>
            {
                Name = "Example valid #1",
                Summary = "All filled",
                Value = new AddSchoolCommand()
                {
                    Name = $" Escola {TypePublicEducation.Municipal} {faker.Person.FullName}",
                    Address = new AddressInputModel(faker.Address.StreetName(), faker.Address.City(), faker.Address.State(), faker.Address.StreetSuffix()),
                    Students = new List<StudentInputModel>()
                    {
                       new StudentInputModel(id, faker.Person.FullName, faker.Person.Email, new ParentsInputModel(faker.Random.Guid(), id, faker.Person.FullName, faker.Person.Email, Domain.Enums.Parent.Father)),
                       
                    },
                    TypePublicEducation = TypePublicEducation.Municipal
                }
            };
        }
    }
}
