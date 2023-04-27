using MediatR;
using SchoolAdersonDeMenezes.Domain.Entities;
using SchoolAdersonDeMenezes.Domain.Repositories;
using SchoolAdersonDeMenezes.Infraestructure.MessageBus;

namespace SchoolAdersonDeMenezes.Application.Commands.Handlers
{
    public class AddSchoolHandler : IRequestHandler<AddSchoolCommand, Guid>
    {
        private readonly ISchoolRepository _repository;
        private readonly IMessageBusClient _messageBus;
        public AddSchoolHandler(ISchoolRepository repository, IMessageBusClient messageBus)
        {
            _repository = repository;
            _messageBus = messageBus;
        }
        public async Task<Guid> Handle(AddSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = request.ToEntity();
            await _repository.AddAsync(school);

            foreach (var @event in school.Events)
            {
              var routingKey = @event.GetType().Name.ToDashCase();

              _messageBus.Publish(@event, routingKey, "school-service");
            }

            return school.Id;
        }
    }
}
