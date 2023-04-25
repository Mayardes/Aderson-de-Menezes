using SchoolAdersonDeMenezes.Application.Queries;
using Swashbuckle.AspNetCore.Filters;

namespace SchoolAdersonDeMenezes.Api.Controllers.v1.RequestExamples
{
    public class SchoolGetByIdRequestExample : IMultipleExamplesProvider<GetSchoolByIdQuery>
    {
        public IEnumerable<SwaggerExample<GetSchoolByIdQuery>> GetExamples()
        {
            yield return new SwaggerExample<GetSchoolByIdQuery>
            {
                Name = "Example valid #1",
                Summary = "All filled",
                Value = new GetSchoolByIdQuery
                {
                    Id = Guid.NewGuid()
                }
            };

            yield return new SwaggerExample<GetSchoolByIdQuery>
            {
                Name = "Example invalid #1",
                Summary = "No Id filled",
                Value = new GetSchoolByIdQuery()
            };
        }
    }
}
