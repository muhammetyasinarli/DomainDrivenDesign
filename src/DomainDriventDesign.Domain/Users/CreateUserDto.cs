namespace DomainDriventDesign.Domain.Users
{
    public sealed record CreateUserDto(string Name, 
        string Email, 
        string Password, 
        string Country,
        string City,
        string Street,
        string PostalCode,
        string FullAddress);
}
