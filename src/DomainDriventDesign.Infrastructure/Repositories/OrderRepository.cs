using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Orders;
using DomainDriventDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static DomainDriventDesign.Domain.Orders.Order;

namespace DomainDriventDesign.Infrastructure.Repositories
{
    internal sealed class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default)
        {
            Order order = new Order(Guid.NewGuid(), "ORC"+ (new Random()).Next(), DateTime.Now, OrderStatusEnum.AwaitingApproval);

            order.CreateOrder(createOrderDtos);

            await _context.Orders.AddAsync(order);

            return order;
        }

        public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Orders.ToListAsync();
        }
    }
}
