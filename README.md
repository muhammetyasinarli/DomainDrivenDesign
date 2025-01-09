An Example Project Developed Using Clean Architecture and Domain-Driven Design

## Domain Driven Design(Eric Evans)
**Below are key principles;**
- Focus on the Core Domain
- Ubiquitous language; develop a shared language between developers and domain experts to minimize misunderstandings.
- Bounded Context; Divide the domain into Bounded Contexts—logical boundaries where a specific model is valid.
- Collaborate with domain experts to refine the model iteratively.
- Aggregate Design; Group related entities together into Aggregates with a clear root entity (the Aggregate Root).
- Entity ; Objects with a unique identity and lifecycle (e.g., a Customer or Order).
- Value Object;  Immutable objects that represent a concept and lack a unique identity (e.g., Money or Address).
- Domain Events; Events should reflect something meaningful to the business (e.g., "OrderPlaced").
- Use Anticorruption Layer to ensure that interactions between different bounded contexts do not pollute the domain model.
- Clean Architecture
- Strategic Design; Combine the technical model with business strategy
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

## How to run?
- `cd DomainDrivenDesign\src `
- `docker-compose up `
