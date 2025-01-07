using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace DomainDriventDesign.Application.Features.Categories.CreateCategory
{
    public sealed record CreateCategoryCommand(string Name): IRequest;
}
