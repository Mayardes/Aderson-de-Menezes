using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolAdersonDeMenezes.Api.Controllers.v1.RequestExamples;
using SchoolAdersonDeMenezes.Application.Commands;
using SchoolAdersonDeMenezes.Application.Queries;
using Swashbuckle.AspNetCore.Filters;

namespace SchoolAdersonDeMenezes.Api.Controllers.v1
{
    [ApiController]
    [Route("v1/school")]
    public class SchoolController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SchoolController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("{id:Guid}")]
        [SwaggerRequestExample(typeof(Guid), typeof(SchoolGetByIdRequestExample))]
        public async Task<IActionResult> GetById(Guid id)
        {
            var request = new GetSchoolByIdQuery() { Id = id };
            var result = await _mediator.Send(request);

            if(result == null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost]
        [SwaggerRequestExample(typeof(AddSchoolCommand), typeof(SchoolPostRequestExample))]
        public async Task<IActionResult> Post([FromBody] AddSchoolCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result}, command);
        }
    }
}
