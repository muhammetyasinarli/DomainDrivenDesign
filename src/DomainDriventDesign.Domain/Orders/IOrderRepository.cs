using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DomainDriventDesign.Domain.Orders.Order;

namespace DomainDriventDesign.Domain.Orders
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken= default);
        Task <List<Order>> GetAllAsync(CancellationToken cancellationToken= default);
    }
}
