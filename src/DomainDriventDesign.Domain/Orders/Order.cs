using DomainDriventDesign.Domain.Abstractions;
using DomainDriventDesign.Domain.Shared;

namespace DomainDriventDesign.Domain.Orders
{
    public sealed partial class Order: Entity
    {
        private Order(Guid id) : base(id) { }
        public Order(Guid id,string orderNumber, DateTime createDate, OrderStatusEnum status)
            :base(id)
        {
            OrderNumber = orderNumber;
            CreateDate = createDate;
            Status = status;
        }

        public string OrderNumber { get; private set; }
        public DateTime CreateDate { get; private set; }
        public OrderStatusEnum Status { get; private set; }
        public ICollection<OrderLine> OrderLines { get; private set; } = new List<OrderLine>();

        public void CreateOrder(List<CreateOrderDto> createOrderDtos) {
            foreach (var item in createOrderDtos) {

                if (item.Quantity <= 0) { throw new ArgumentException("Sipari miktarı 0 dan büyük olmalıdır!"); }

                //kalan iş kuralları

                OrderLine orderLine = new(Guid.NewGuid(), item.ProductId, item.Quantity, new(item.Amount, Currency.FromCode(item.Currency)));
                OrderLines.Add(orderLine);
            }
        }

        public void RemoveOrderLine(Guid id)
        {
            var orderLine = OrderLines.FirstOrDefault(p => p.Id == id);
            if (orderLine == null)
            {
                throw new ArgumentException("Silmek istediğiniz sipariş kalemi bulunamadı");
            }

            OrderLines.Remove(orderLine);
        }
      
    }
}
