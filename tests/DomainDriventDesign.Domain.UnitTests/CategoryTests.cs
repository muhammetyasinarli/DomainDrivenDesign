using DomainDriventDesign.Domain.Abstractions;
using DomainDriventDesign.Domain.Categories;
using DomainDriventDesign.Domain.Shared;

namespace DomainDriventDesign.Domain.UnitTests
{
    public class CategoryTests
    {
        [Fact]
        public void CreateCategory_WithValidParameters_CreatesCategory()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = new Name("Electronics");

            // Act
            var category = new Category(id, name);

            // Assert
            Assert.NotNull(category);
            Assert.Equal(id, category.Id);
            Assert.Equal(name, category.Name);
        }

        [Fact]
        public void ChangeName_WithValidName_ChangesCategoryName()
        {
            // Arrange
            var id = Guid.NewGuid();
            var initialName = new Name("Electronics");
            var category = new Category(id, initialName);
            var newName = "Home Appliances";

            // Act
            category.ChangeName(newName);

            // Assert
            Assert.Equal(new Name(newName), category.Name);
        }
    }
}