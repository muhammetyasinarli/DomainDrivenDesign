using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Products;
using MediatR;

namespace DomainDriventDesign.Application.Features.Products.GetAllProduct
{
    public sealed record GetAllProductQuery(): IRequest<List<Product>>;
}
