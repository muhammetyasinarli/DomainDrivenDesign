using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Categories;
using DomainDriventDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDriventDesign.Infrastructure.Repositories
{
    internal sealed class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
        {
            var category = new Category(Guid.NewGuid(), new (name));

            await _context.Categories.AddAsync(category, cancellationToken);
        }

        public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Categories.AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}
