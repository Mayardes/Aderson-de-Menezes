using MediatR;
using SchoolAdersonDeMenezes.Domain.Repositories;
using SchoolAdersonDeMenezes.Infraestructure.MessageBus;
using SchoolAdersonDeMenezes.Infraestructure.ServiceIntegration;
using System.Text;

namespace SchoolAdersonDeMenezes.Application.Commands.Handlers
{
    public class AddSchoolHandler : IRequestHandler<AddSchoolCommand, Guid>
    {
        private readonly ISchoolRepository _repository;
        private readonly IMessageBusClient _messageBus;
        private readonly IGetNotificationServiceIntegration _getNotificationServiceIntegration;
        public AddSchoolHandler(ISchoolRepository repository, IMessageBusClient messageBus, IGetNotificationServiceIntegration getNotificationServiceIntegration)
        {
            _repository = repository;
            _messageBus = messageBus;
            _getNotificationServiceIntegration = getNotificationServiceIntegration;
        }
        public async Task<Guid> Handle(AddSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = request.ToEntity();
            StringBuilder sb = new StringBuilder();

            await _repository.AddAsync(school);

            foreach (var @event in school.Events)
            {
              var routingKey = @event.GetType().Name.ToDashCase();

              _messageBus.Publish(@event, routingKey, "school-service");
            }

            foreach (var student in school.Students)
            {
                sb.AppendLine(await _getNotificationServiceIntegration.SendEmailNotification(student.Email));
            }

            if (sb.Length > 0)
                await Console.Out.WriteLineAsync($"Result request is: {sb}");

            return school.Id;
        }
    }
}
