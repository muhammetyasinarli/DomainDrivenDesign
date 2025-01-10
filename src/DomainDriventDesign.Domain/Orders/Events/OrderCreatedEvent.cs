using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DomainDriventDesign.Domain.Orders.Events
{
    public sealed class OrderCreatedEvent : INotification
    {
        public Order Order { get; set; }

        public OrderCreatedEvent(Order order)
        {
            Order = order;
        }
    }
}
