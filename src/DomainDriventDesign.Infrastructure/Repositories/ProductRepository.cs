using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Products;
using DomainDriventDesign.Domain.Shared;
using DomainDriventDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDriventDesign.Infrastructure.Repositories
{
    internal sealed class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(string name, int quantity, decimal amount, string currency, Guid categoryId, CancellationToken cancellationToken = default)
        {
            var product = new Product(Guid.NewGuid(),
                new(name), 
                quantity, 
                new(amount, Currency.FromCode(currency)), 
                categoryId);

            await _context.Products.AddAsync(product);  
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task UpdateQuantityAsync(Guid id, int quantity, CancellationToken cancellationToken = default)
        {
            var product = await _context.Products.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);

            if (product == null) { return; }

            product.UpdateQuantity(product.Quantity-quantity);
        }
    }
}
