// See https://aka.ms/new-console-template for more information
//using BenchmarkDotNet.Running;

//BenchmarkRunner.Run<BenchMarkService>();

using MediatR;

Order order = new();
order.CreateOrder(1, "Elma");
order.CreateOrder(5, "Elma");

DomainEventDispatcher.Dispatch(order.DomainEvents);
Console.ReadLine();


public class Order
{
    private readonly IMediator mediator;
    public int Id { get; set; }

    public string ProductName { get; set; }

    public List<IDomainEvent> DomainEvents { get; } = new();

    public void CreateOrder(int id, string productName)
    {
        Id = id;
        ProductName = productName;

        //DomainEvents.Add(new OrderCreatedEvent(id));

        mediator.Publish(new OrderCompletedEvent(id));
    }
}

public class StockUpdateHandler : INotificationHandler<OrderCompletedEvent>
{
    public Task Handle(OrderCompletedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

public class OrderCompletedEvent : INotification
{
    public int Id { get; }

    public OrderCompletedEvent(int id) {  Id = id; }
}

public interface IDomainEvent { }

public class OrderCreatedEvent : IDomainEvent
{
    public int OrderId { get; }

    public OrderCreatedEvent(int orderId) { OrderId = orderId; }
}

public static class DomainEventDispatcher 
{
    public static void Dispatch(List<IDomainEvent> domainEvents)
    {
        foreach (IDomainEvent domainEvent in domainEvents)
        {
            if(domainEvent is OrderCreatedEvent orderCreatedEvent)
            {
                Console.WriteLine($"Event İşlemi başladı. Id : {orderCreatedEvent.OrderId}");
            }
           
        }
    }

}

