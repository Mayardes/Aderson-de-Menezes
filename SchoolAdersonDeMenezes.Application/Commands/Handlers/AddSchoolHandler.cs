using MediatR;
using SchoolAdersonDeMenezes.Domain.Repositories;

namespace SchoolAdersonDeMenezes.Application.Commands.Handlers
{
    public class AddSchoolHandler : IRequestHandler<AddSchoolCommand, Guid>
    {
        private readonly ISchoolRepository _repository;
        public AddSchoolHandler(ISchoolRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(AddSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = request.ToEntity();
            return await _repository.AddAsync(school);
        }
    }
}
