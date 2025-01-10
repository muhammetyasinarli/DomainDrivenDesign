using DomainDriventDesign.Domain.Abstractions;
using DomainDriventDesign.Domain.Categories;
using DomainDriventDesign.Domain.Shared;

namespace DomainDriventDesign.Domain.Products
{
    public sealed class Product: Entity
    {
        private Product(Guid id) : base(id) { }
        public Product(Guid id,Name name, int quantity, Money price, Guid categoryId)
            :base(id)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            CategoryId = categoryId;
        }

        public Name Name { get; private set; }
        public int Quantity { get; private set; }
        public Money Price { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public byte[] RowVersion { get; set; }

        public void Update(string name, decimal amount, int quantity, string currency, Guid categoryId)
        {
            Name = new(name);
            Quantity = quantity;
            CategoryId = categoryId;
            Price = new(amount,Currency.FromCode(currency));
        }

        public void UpdateQuantity(int quantity)
        {
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");

            Quantity = quantity;
        }
    }
}
