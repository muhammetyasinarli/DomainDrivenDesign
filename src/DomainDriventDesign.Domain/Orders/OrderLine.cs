using DomainDriventDesign.Domain.Abstractions;
using DomainDriventDesign.Domain.Products;
using DomainDriventDesign.Domain.Shared;

namespace DomainDriventDesign.Domain.Orders
{
    public sealed class OrderLine: Entity
    {
        private OrderLine(Guid id) : base(id) { }
        public OrderLine(Guid id, Guid productId, int quantity, Money price)
            :base(id)
        {
            ProductId = productId;
            Quantity = quantity;
            Price = price;
        }

        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public Money Price { get; private set; }
    }
}
