using SchoolAdersonDeMenezes.Domain.Events;

namespace SchoolAdersonDeMenezes.Domain.Entities
{
    /// <summary>
    /// Aggregate represents a single constancy. Aggregate root is an Entity and might has Events. 
    /// </summary>
    public class AggregateRoot : IEntityBase
    {
        private readonly List<IDomainEvent> _events = new ();
        public Guid Id { get; protected set; }

        public IEnumerable<IDomainEvent> Events => _events;
        protected void AddEvent(IDomainEvent @event)
        {
            if(@event == null)
                throw new ArgumentNullException(nameof(@event));
            _events.Add(@event);
        }
    }
}
