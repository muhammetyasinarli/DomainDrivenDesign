using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Orders;
using static DomainDriventDesign.Domain.Orders.Order;

namespace DomainDriventDesign.Domain.UnitTests
{
    public class OrderTests
    {
        [Fact]
        public void CreateOrder_WithValidParameters_CreatesOrder()
        {
            // Arrange
            var id = Guid.NewGuid();
            var orderNumber = "ORD123";
            var createDate = DateTime.UtcNow;
            var status = OrderStatusEnum.AwaitingApproval;

            // Act
            var order = new Order(id, orderNumber, createDate, status);

            // Assert
            Assert.NotNull(order);
            Assert.Equal(id, order.Id);
            Assert.Equal(orderNumber, order.OrderNumber);
            Assert.Equal(createDate, order.CreateDate);
            Assert.Equal(status, order.Status);
            Assert.Empty(order.OrderLines); // Başlangıçta sipariş kalemi olmamalı
        }

        [Fact]
        public void CreateOrder_WithValidOrderLines_AddsOrderLines()
        {
            // Arrange
            var id = Guid.NewGuid();
            var order = new Order(id, "ORD123", DateTime.UtcNow, OrderStatusEnum.AwaitingApproval);
            var createOrderDtos = new List<CreateOrderDto>
            {
                new CreateOrderDto(Guid.NewGuid(), 100m, 2, "Usd"),
                new CreateOrderDto(Guid.NewGuid(), 50m, 1, "Usd")
            };

            // Act
            order.CreateOrder(createOrderDtos);

            // Assert
            Assert.Equal(2, order.OrderLines.Count);
        }

        [Fact]
        public void CreateOrder_WithInvalidQuantity_ThrowsArgumentException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var order = new Order(id, "ORD123", DateTime.UtcNow, OrderStatusEnum.AwaitingApproval);
            var createOrderDtos = new List<CreateOrderDto>
            {
                new CreateOrderDto(Guid.NewGuid(), 100m, 0, "Usd") // Geçersiz miktar
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => order.CreateOrder(createOrderDtos));
            Assert.Equal("Sipari miktarı 0 dan büyük olmalıdır!", exception.Message);
        }

        [Fact]
        public void RemoveOrderLine_WithValidId_RemovesOrderLine()
        {
            // Arrange
            var id = Guid.NewGuid();
            var order = new Order(id, "ORD123", DateTime.UtcNow, OrderStatusEnum.AwaitingApproval);
            var createOrderDtos = new List<CreateOrderDto>
            {
                new CreateOrderDto(Guid.NewGuid(), 100m, 2, "Usd"),
                new CreateOrderDto(Guid.NewGuid(), 50m, 1, "Usd")
            };
            order.CreateOrder(createOrderDtos);
            var orderLineIdToRemove = order.OrderLines.First().Id;

            // Act
            order.RemoveOrderLine(orderLineIdToRemove);

            // Assert
            Assert.Equal(1, order.OrderLines.Count);
        }

        [Fact]
        public void RemoveOrderLine_WithInvalidId_ThrowsArgumentException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var order = new Order(id, "ORD123", DateTime.UtcNow, OrderStatusEnum.AwaitingApproval);
            var createOrderDtos = new List<CreateOrderDto>
            {
                new CreateOrderDto(Guid.NewGuid(), 100m, 2, "Usd")
            };
            order.CreateOrder(createOrderDtos);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => order.RemoveOrderLine(Guid.NewGuid())); // Geçersiz ID
            Assert.Equal("Silmek istediğiniz sipariş kalemi bulunamadı", exception.Message);
        }
    }
}
