using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Categories;
using MediatR;

namespace DomainDriventDesign.Application.Features.Categories.GetAllCategory
{
    public sealed record GetAllCategoryQuery : IRequest<List<Category>>;
}
