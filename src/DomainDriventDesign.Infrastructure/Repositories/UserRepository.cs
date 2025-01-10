using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Users;
using DomainDriventDesign.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DomainDriventDesign.Infrastructure.Repositories
{
    internal sealed class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> CreateAsync(CreateUserDto createUserDto, CancellationToken cancellationToken = default)
        {
            var user = User.CreateUser(createUserDto);

            await _context.Users.AddAsync(user, cancellationToken);

            return user;
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Users.ToListAsync(cancellationToken);
        }
    }
}
