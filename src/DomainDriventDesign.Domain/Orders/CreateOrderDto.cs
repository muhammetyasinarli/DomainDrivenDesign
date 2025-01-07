namespace DomainDriventDesign.Domain.Orders
{
    public sealed partial class Order
    {
        public sealed record CreateOrderDto(Guid ProductId, decimal Amount, int Quantity, string Currency);
      
    }
}
