using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Products;
using DomainDriventDesign.Domain.Shared;

namespace DomainDriventDesign.Domain.UnitTests
{
    public class ProductTests
    {
        [Fact]
        public void CreateProduct_WithValidParameters_CreatesProduct()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = new Name("Laptop");
            var quantity = 10;
            var amount = 999.99m;
            var currency = "Usd";
            var categoryId = Guid.NewGuid();

            // Act
            var product = new Product(id, name, quantity, new Money(amount, Currency.FromCode(currency)), categoryId);

            // Assert
            Assert.NotNull(product);
            Assert.Equal(id, product.Id);
            Assert.Equal(name, product.Name);
            Assert.Equal(quantity, product.Quantity);
            Assert.Equal(amount, product.Price.Amount);
            Assert.Equal(currency, product.Price.Currency.Code);
            Assert.Equal(categoryId, product.CategoryId);
        }

        [Fact]
        public void UpdateQuantity_WithValidQuantity_UpdatesProductQuantity()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = new Name("Laptop");
            var quantity = 10;
            var amount = 999.99m;
            var currency = "Usd";
            var categoryId = Guid.NewGuid();
            var product = new Product(id, name, quantity, new Money(amount, Currency.FromCode(currency)), categoryId);

            // Act
            product.UpdateQuantity(20);

            // Assert
            Assert.Equal(20, product.Quantity);
        }

        [Fact]
        public void UpdateQuantity_WithNegativeQuantity_ThrowsArgumentException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = new Name("Laptop");
            var quantity = 10;
            var amount = 999.99m;
            var currency = "Usd";
            var categoryId = Guid.NewGuid();
            var product = new Product(id, name, quantity, new Money(amount, Currency.FromCode(currency)), categoryId);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => product.UpdateQuantity(-5));
            Assert.Equal("Quantity cannot be negative.", exception.Message);
        }
    }
}
