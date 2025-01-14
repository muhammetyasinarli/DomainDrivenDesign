using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainDriventDesign.Domain.Users;

namespace DomainDriventDesign.Domain.UnitTests
{
    public class UserTests
    {
        [Fact]
        public void CreateUser_WithValidParameters_CreatesUser()
        {
            // Arrange
            var createUserDto = new CreateUserDto(
                "John Doe",
                "john.doe@example.com",
                "SecurePassword123",
                "USA",
                "New York",
                "5th Avenue",
                "10001",
                "5th Avenue, New York, USA"
            );

            // Act
            var user = User.CreateUser(createUserDto);

            // Assert
            Assert.NotNull(user);
            Assert.Equal(createUserDto.Name, user.Name.Value);
            Assert.Equal(createUserDto.Email, user.Email.Value);
            Assert.Equal(createUserDto.Password, user.Password.Value);
            Assert.Equal(createUserDto.Country, user.Address.Country);
            Assert.Equal(createUserDto.City, user.Address.City);
            Assert.Equal(createUserDto.Street, user.Address.Street);
            Assert.Equal(createUserDto.PostalCode, user.Address.PostalCode);
            Assert.Equal(createUserDto.FullAddress, user.Address.FullAddress);
        }

        [Fact]
        public void ChangeEmail_WithValidEmail_ChangesUserEmail()
        {
            // Arrange
            var createUserDto = new CreateUserDto(
                "John Doe",
                "john.doe@example.com",
                "SecurePassword123",
                "USA",
                "New York",
                "5th Avenue",
                "10001",
                "5th Avenue, New York, USA"
            );
            var user = User.CreateUser(createUserDto);
            var newEmail = "john.new@example.com";

            // Act
            user.ChangeEmail(newEmail);

            // Assert
            Assert.Equal(newEmail, user.Email.Value);
        }

        [Fact]
        public void ChangePassword_WithValidPassword_ChangesUserPassword()
        {
            // Arrange
            var createUserDto = new CreateUserDto(
                "John Doe",
                "john.doe@example.com",
                "SecurePassword123",
                "USA",
                "New York",
                "5th Avenue",
                "10001",
                "5th Avenue, New York, USA"
            );
            var user = User.CreateUser(createUserDto);
            var newPassword = "NewSecurePassword456";

            // Act
            user.ChangePassword(newPassword);

            // Assert
            Assert.Equal(newPassword, user.Password.Value);
        }

        [Fact]
        public void ChangeAddress_WithValidAddress_ChangesUserAddress()
        {
            // Arrange
            var createUserDto = new CreateUserDto(
                "John Doe",
                "john.doe@example.com",
                "SecurePassword123",
                "USA",
                "New York",
                "5th Avenue",
                "10001",
                "5th Avenue, New York, USA"
            );
            var user = User.CreateUser(createUserDto);
            var newAddress = new Address("Canada", "Toronto", "Queen St", "M5H 2N2", "Queen St, Toronto, Canada");

            // Act
            user.ChangeAddress(newAddress);

            // Assert
            Assert.Equal(newAddress, user.Address);
        }

        [Fact]
        public void ChangeName_WithValidName_ChangesUserName()
        {
            // Arrange
            var createUserDto = new CreateUserDto(
                "John Doe",
                "john.doe@example.com",
                "SecurePassword123",
                "USA",
                "New York",
                "5th Avenue",
                "10001",
                "5th Avenue, New York, USA"
            );
            var user = User.CreateUser(createUserDto);
            var newName = "Jane Doe";

            // Act
            user.ChangeName(newName);

            // Assert
            Assert.Equal(newName, user.Name.Value);
        }
    }
}
