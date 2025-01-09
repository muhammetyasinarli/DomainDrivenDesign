namespace DomainDriventDesign.Domain.Users
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(CreateUserDto createUserDto, CancellationToken cancellationToken=default);

        Task<List<User>> GetAllAsync(CancellationToken  cancellationToken = default);
    }
}
