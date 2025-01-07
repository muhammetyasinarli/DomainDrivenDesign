using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Orders;
using MediatR;

namespace DomainDriventDesign.Application.Features.Orders.GetAllOrder
{
    public sealed record GetAllOrderQuery(): IRequest<List<Order>>;
}
