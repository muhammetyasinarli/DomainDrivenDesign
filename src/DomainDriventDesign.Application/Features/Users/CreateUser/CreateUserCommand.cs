using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MediatR;

namespace DomainDriventDesign.Application.Features.Users.CreateUser
{
    public sealed record CreateUserCommand(string Name, 
        string Email, 
        string Password, 
        string Country,
        string City,
        string Street,
        string PostalCode,
        string FullAddress) : IRequest;
}
