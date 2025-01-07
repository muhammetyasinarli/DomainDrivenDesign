using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Shared;
using MediatR;

namespace DomainDriventDesign.Application.Features.Products.CreateProduct
{
    public sealed record CreateProductCommand(string Name, int Quantity, decimal Amount, string Currency, Guid CategoryId) : IRequest;
}
