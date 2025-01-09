using DomainDriventDesign.Domain.Users;
using MediatR;

namespace DomainDriventDesign.Application.Features.Users.CreateUser
{
    public sealed record CreateUserCommand(CreateUserDto createUserDto) : IRequest;
}
