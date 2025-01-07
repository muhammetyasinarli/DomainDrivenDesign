using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Users;
using MediatR;

namespace DomainDriventDesign.Application.Features.Users.GetAllUser
{
    public sealed record GetAllUserQuery : IRequest<List<User>>;
}
