using DomainDriventDesign.Domain.Abstractions;
using DomainDriventDesign.Domain.Shared;

namespace DomainDriventDesign.Domain.Users
{
    public sealed class User: Entity
    {
        private User(Guid id) : base(id) { }
        private User(Guid id, Name name, Email email, Password password, Address address) : base(id)
        {
            Name = name;
            Email = email;
            Password = password;
            Address = address;
        }

        public static User CreateUser(string name, string email, string password, string country,
        string city,
        string street,
        string postalCode,
        string fullAddress)
        {
            User user = new(id: Guid.NewGuid(),
                name: new Name(name),
                email: new Email(email),
                password: new Password(password),
                address: new(country, city, street, postalCode, fullAddress));

            return user;
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public Address Address { get; private set; }

        public void ChangeAddress(Address address)
        {
            Address = address;
        }

        public void ChangePassword(string password)
        {
            Password = new(password);
        }

        public void ChangeEmail(string email)
        {
            Email = new(email);
        }

        public void ChangeName(string name) 
        { 
            Name = new(name);
        }
    }
}
