using DomainDriventDesign.Domain.Users.Events;
using MediatR;

namespace DomainDriventDesign.Application.Features.Notification.EventHandlers
{
    public sealed class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
