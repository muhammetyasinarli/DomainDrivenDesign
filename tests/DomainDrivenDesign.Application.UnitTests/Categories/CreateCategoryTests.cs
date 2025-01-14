using DomainDriventDesign.Application.Features.Categories.CreateCategory;
using DomainDriventDesign.Domain.Abstractions;
using DomainDriventDesign.Domain.Categories;
using Moq;

namespace DomainDrivenDesign.Application.UnitTests.Categories
{
    public class CreateCategoryTests
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly CreateCategoryCommandHandler _handler;

        public CreateCategoryTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _handler = new CreateCategoryCommandHandler(_categoryRepositoryMock.Object, _unitOfWorkMock.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_CreatesCategory()
        {
            // Arrange
            var command = new CreateCategoryCommand("Electronics");

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _categoryRepositoryMock.Verify(repo => repo.CreateAsync(command.Name, It.IsAny<CancellationToken>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenExceptionThrown_ShouldHandleGracefully()
        {
            // Arrange
            var command = new CreateCategoryCommand("Electronics");
            _categoryRepositoryMock
                .Setup(repo => repo.CreateAsync(command.Name, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _handler.Handle(command, CancellationToken.None));
            _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
