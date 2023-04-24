using MediatR;
using SchoolAdersonDeMenezes.Application.Dtos.ViewModels;
using SchoolAdersonDeMenezes.Domain.Repositories;

namespace SchoolAdersonDeMenezes.Application.Queries.Handlers
{
    public class GetSchoolByIdHandler : IRequestHandler<GetSchoolByIdQuery, SchoolViewModel>
    {
        private readonly ISchoolRepository _repository;
        public GetSchoolByIdHandler(ISchoolRepository repository)
        {
            _repository = repository;
        }
        public async Task<SchoolViewModel> Handle(GetSchoolByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);

            return request.FromEntity(result);
        }
    }
}
