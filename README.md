An Example Project Developed Using Clean Architecture and Domain-Driven Design

## How to run?
- `cd DomainDrivenDesign\src `
- `docker-compose up `

## Domain Driven Design(Eric Evans)
**Below are key principles;**
- Focus on the Core Domain
- Tactical design focuses on the implementation details within a specific bounded context. It provides tools and patterns to model and implement the domain logic effectively.
  - Building Blocks; Entities, Value Objects, Aggregates, Repositories, Factories, Domain Events 
- Strategic Design; Combine the technical model with business strategy. Strategic design focuses on the big picture of how different parts of a system interact and align with the business.
  - Bounded Context, Context Mapping, Subdomains, Integration Patterns 
- Bounded Context; Divide the domain into Bounded Contexts—logical boundaries. A bounded context is a technical boundary for implementing a domain model. Each bounded context contains a consistent model and a Ubiquitous Language.
- Ubiquitous language; develop a shared language between developers and domain experts to minimize misunderstandings. 
- Subdomain; A subdomain is a logical partition of the business domain. Subdomains are "the problem space" (what the business does) and bounded contexts are "the solution space" (how we implement solutions).
- Context Mappings; Context mapping defines how bounded contexts interact.
  - ACL; context uses an adapter or translation layer to shield itself from the model of another context.
  - Two contexts operate independently and do not share data or interact directly.
- Collaborate with domain experts to refine the model iteratively.
- Aggregate Design; Group related entities together into Aggregates with a clear root entity (the Aggregate Root).
- Entity ; Objects with a unique identity and lifecycle (e.g., a Customer or Order).
- Value Object;  Immutable objects that represent a concept and lack a unique identity (e.g., Money or Address).
- Domain Events; Events should reflect something meaningful to the business (e.g., "OrderPlaced").
- CQRS; Separate commands (write operations) and queries (read operations) to handle complex business logic more effectively.
- Facory; It produces complicated aggregates or sometimes also entities and value objects. 

## Clean Architecture (Robert C. Martin (Uncle Bob))
Clean Architecture is not about enforcing fixed layers; it’s about adhering to its core principles, such as dependency inversion, separation of concerns, and encapsulation of business logic.
I prefer to use the Domain, Application, Infrastructure, and Web API layers from the inside out
![Clean Architecture](https://miro.medium.com/v2/resize:fit:751/0*SNw3dawnE8WhVkJb.png)
 
**Why Clean Architecture?**
- Separation of concerns; Separate business logic from infrastructure concerns.
- Avoid polluting the domain layer with concerns like database access, frameworks, or external integrations.
- Enable testability, maintainability, and flexibility.
- dependency inversion; the domain layer depends on abstractions rather than concrete implementations.

## Repository and Unit of Work Patterns
Repository Pattern helps abstract data access and prevents database query operations from being performed directly. It prevents query and code duplication and provides seperation of concerns.
It provides maintability, flexibility and testability as well.

> Martin Fowler.
> 
> A Repository mediates between the domain and data mapping layers, acting like an in-memory domain object collection.

The repository’s job is to manage the collection of domain objects, including adding, updating, and removing them from the database, abstracting the data access logic away from the business layer.

**Why do we need Unit of Work Pattern?**
Unit of Work ensures that multiple operations (such as adding or updating several entities) are handled as a single unit, meaning that all changes are committed to the database together to maintain consistency.
The repository encapsulates the interaction with the database, its role does include adding, updating, or removing entities in the context of data persistence. The repository does not directly handle complex database transactions or coordination across multiple repositories

> Martin Fowler.
> 
> A Unit of Work keeps track of everything you do during a business transaction that can affect the database. When you’re done, it figures out everything that needs to be done to alter the database as a result of your work.

**Why didn't I use a generic repository?**
Generic Repositories can be problematic in Domain Driven Design due to the lack of domain-specific logic, it is often better to design repositories specific to aggregates or domain entities.

## Mediator Pattern and CQRS
Instead of objects communicating directly with each other, they interact through a central mediator, which manages the communication. This pattern helps in reducing dependencies and improving code maintainability.
I prefer using the MediatR library to implement the mediator pattern. It is a part of the Gang of Four (GoF) design patterns as well.

CQRS is a design pattern where commands (operations that change data) and queries (operations that retrieve data) are segregated into separate models. This allows for better scalability, clear separation of concerns, and optimization of read/write operations.
CQRS is particularly effective for domain-driven design (DDD), especially in systems with complex business rules.

The Mediator Pattern is commonly used with CQRS to streamline how commands and queries are handled. 

## EF Core Best Practices

**IsRowVersion**
To protect against race conditions in Entity Framework Core (EF Core), I prefer Row Versioning strategy. I explicitly specified the property as a concurrency token with IsRowVersion() in the OnModelCreating method:
`    modelBuilder.Entity<Product>().Property(p => p.RowVersion).IsRowVersion();  `

It is a kind of optimistic concurrency, the RowVersion (or equivalent concurrency token) is updated by the database automatically during every update operation. When reading data, a concurrency token (e.g., RowVersion) is retrieved with the data. When saving data, the system compares the original value of the concurrency token (stored at read time) with the current value in the database. If the values match, the update proceeds. If not, a DbUpdateConcurrencyException is thrown, indicating a conflict.

What is Pessimistic Concurrency?
Pessimistic concurrency assumes conflicts are frequent and avoids them by locking the data at the database level. When a user reads or modifies a record, the system places a lock on the record, preventing others from reading or updating it until the lock is released.
In EF Core, we can use transactions and locks to implement pessimistic concurrency.
**For distributed systems, in-memory locks should be avoided in favor of database or distributed locking mechanisms.**

I think optimistic concurrency is generally better suited for many modern applications compared to pessimistic concurrency when considering performance, scalability. However Pessimistic Concurrency is needed for critical transactions where locks guarantee safety. 

**AsNoTracking**
AsNoTracking() improves performance by skipping the change tracking process for the retrieved entities. It's ideal for read-only operations where you don't intend to update the entities later.

**Load data in EF Core**
3 ways to load data in EF Core ; Select Loading> Eager Loading> Lazy Loading
Select Loading is the most efficient method when you need to load only specific fields or data from a related entity, avoiding the overhead of loading unnecessary related data.
Eager Loading allows you to load related entities along with the primary entity in a single query using Include(). With eager loading, you use Include() to load related data in the same query, which results in one query with a JOIN operation.
Lazy Loading is a technique where related data is automatically loaded when it is accessed, typically by accessing a navigation property on the entity
Slowest compared to the other two methods because it can result in N+1 query problem, where a new query is executed for each related entity.

**Async Calls**
it’s important to always use asynchronous APIs rather than synchronous ones. Synchronous APIs block the thread for the duration of database I/O, increasing the need for threads. Using synchronous code in certain situations can lead to thread starvation problems, particularly in environments with a limited thread pool, such as web servers or applications using a thread pool-based architecture (e.g., ASP.NET).

##  DI Lifetimes ##

- Singelton
  - Settings (such as configuration values loaded from appsettings.json or other sources) are typically registered with a singleton lifetime. This is because settings are generally immutable, shared across the entire application, and do not need to be reloaded for each request.
  - The lifetime of the IMapper registered by builder.Services.AddAutoMapper() is singleton by default.
  - The MongoClient class is designed to be thread-safe and reusable across the entire application.
  - Redis client libraries (e.g., StackExchange.Redis) are thread-safe and maintain an internal connection pool.
  - The CosmosClient from the Azure Cosmos DB SDK is thread-safe and manages its own connection pool.
- Scoped
  - DbContext is not thread-safe and should be created per request or per operation. (AddDbContext, AddNpgsqlDbContext ,AddSqlServerDbContext, etc.)  DbContext in Entity Framework Core follows the Unit of Work pattern. Scoped lifetime ensures proper management of entity state, transactions, and database connections within the lifecycle of a unit of work (e.g., HTTP request).
  - Repository, I prefer to use scoped repository classes with EF Core.
  - AddMediatR,  scope is the recommended and default lifetime of MediatR. In a typical web application, this ensures that all dependencies required by MediatR handlers (e.g., database contexts or services) also respect the scope of the request and are disposed of after the request is completed.

- Transient
  - Dapper, Since Dapper does not track entities or manage complex transactions (like EF Core), there’s no need to maintain the connection for the entire request scope as you would with DbContext.
  - Repository, I prefer to use transient repository classes with Dapper
  - In .NET Core, the lifetime of AddHttpClient is Transient by default. However, it is typically used in conjunction with IHttpClientFactory, which manages the lifecycle of HttpClient.

**Dependency Injection Problems**
- Circular References;  When two or more services depend on each other directly or indirectly, creating a cycle that the DI container cannot resolve. For the solution, refactor the design to break the circular dependencies.
- Scope Issues; Improper handling of service lifetimes (e.g., mistakenly using Singleton for services that should be scoped or transient) can cause memory leaks or excessive memory usage. Singleton services are not disposed of until the application ends (or the host is disposed), which means that the Transient service reference held by the Singleton will also never be disposed of as long as the Singleton is alive. This can lead to a memory leaks.

## Test Techniques
- Unit Testing; Unit testing is a software testing technique where individual units or components of a program are tested in isolation to ensure they function as expected. Each "unit" (e.g., a function, method, or class) is tested independently of other components. Dependencies are often mocked or stubbed to isolate the unit being tested.
- Functional Testing; It tests the application’s end-to-end functionality to ensure it meets the needs of the end user.Tests the complete functionality of a system, not individual components. Tests real-world user actions, like logging in, creating an order, or submitting a form. Tests with real or integrated components not mocks.
- Integration Testing; Integration testing is a type of software testing where individual units or components are combined and tested as a group to verify how they work together. It ensures that interactions between different modules, services, or systems function as expected.

**Ex**
You are testing the "Add to Cart" feature in an e-commerce website.
Test individual functions or methods in isolation. Use mocks for dependencies. Test addItemToCart() to ensure it handles valid and invalid inputs correctly. => Unit Testing
Test how components work together (e.g., services, APIs, and databases). Verify Cart Service interacts correctly with Inventory Service and the Database. => Integration testing
Test end-to-end user functionality. Test the full "Add to Cart" workflow, including UI, APIs, and backend interactions. Don't use mocks. => Functional Testing
