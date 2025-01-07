using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using static DomainDriventDesign.Domain.Orders.Order;

namespace DomainDriventDesign.Application.Features.Orders.CreateOrder
{
    public sealed record CreateOrderCommand(List<CreateOrderDto> CreateOrderDtos): IRequest;
}
