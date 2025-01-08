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
- CQRS

## Clean Architecture (Robert C. Martin (Uncle Bob))

**Why Clean Architecture?**
- Separation of concerns; Separate business logic from infrastructure concerns.
- Avoid polluting the domain layer with concerns like database access, frameworks, or external integrations.
- Enable testability, maintainability, and flexibility.
- dependency inversion; the domain layer depends on abstractions rather than concrete implementations.

## How to run?
- `cd DomainDrivenDesign\src `
- `docker-compose up `
