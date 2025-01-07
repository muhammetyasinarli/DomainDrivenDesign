using DomainDriventDesign.Domain.Orders;
using MediatR;

namespace DomainDriventDesign.Application.Features.Orders.GetAllOrder
{
    public sealed class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<Order>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAllAsync(cancellationToken);
        }
    }
}
