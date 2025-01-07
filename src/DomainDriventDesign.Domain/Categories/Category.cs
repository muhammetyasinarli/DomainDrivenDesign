using DomainDriventDesign.Domain.Abstractions;
using DomainDriventDesign.Domain.Products;
using DomainDriventDesign.Domain.Shared;

namespace DomainDriventDesign.Domain.Categories
{
    public sealed class Category: Entity
    {
        private Category(Guid id) : base(id) { }
        public Category(Guid id,Name name):base(id)
        {
            Name = name;
        }

        public Name Name { get; private set; }
        public ICollection<Product> Products { get; private set; }


        public void ChangeName(string name)
        {
            Name = new(name);
        }
    }
}
