namespace DomainDriventDesign.Domain.Users
{
    public sealed record Address(string Country,
        string City,
        string Street,
        string PostalCode,
        string FullAddress
        );
}
