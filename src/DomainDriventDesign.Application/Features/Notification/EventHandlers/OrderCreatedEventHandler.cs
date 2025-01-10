using DomainDriventDesign.Domain.Orders.Events;
using MediatR;

namespace DomainDriventDesign.Application.Features.Notification.EventHandlers
{
    public sealed class OrderCreatedEventHandler : INotificationHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
