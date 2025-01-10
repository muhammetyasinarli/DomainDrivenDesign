using DomainDriventDesign.Domain.Abstractions;
using DomainDriventDesign.Domain.Orders;
using DomainDriventDesign.Domain.Orders.Events;
using DomainDriventDesign.Domain.Products;
using MediatR;

namespace DomainDriventDesign.Application.Features.Orders.CreateOrder
{
    internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, 
            IUnitOfWork unitOfWork, 
            IMediator mediator,
            IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _productRepository = productRepository;
        }
        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.CreateAsync(request.CreateOrderDtos, cancellationToken);

            foreach (var orderLine in order.OrderLines) 
            {
                await _productRepository.UpdateQuantityAsync(orderLine.ProductId,
                        orderLine.Quantity,
                        cancellationToken);
            }

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new OrderCreatedEvent(order), cancellationToken);
        }
    }
}
