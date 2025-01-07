using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DomainDriventDesign.Domain.Orders.Events
{
    public sealed class SendOrderEmailEvent : INotificationHandler<OrderDomainEvent>
    {
        public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
