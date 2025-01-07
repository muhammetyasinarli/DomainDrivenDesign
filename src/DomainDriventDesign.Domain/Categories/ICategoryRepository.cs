using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDriventDesign.Domain.Categories
{
    public interface ICategoryRepository
    {
        Task CreateAsync(string name, CancellationToken cancellationToken = default);

        Task<List<Category>> GetAllAsync(CancellationToken cancellationToken= default);

    }
}
