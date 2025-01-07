using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DomainDriventDesign.Domain.Users.Events
{
    public sealed class SendRegisterEmailEvent : INotificationHandler<UserDomainEvent>
    {
        public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
