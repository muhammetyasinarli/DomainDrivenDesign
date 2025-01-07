namespace DomainDriventDesign.Domain.Abstractions
{
    public abstract class Entity: IEquatable<Entity>
    {
        public Guid Id { get; init; }

        public Entity(Guid id) {  Id = id; }

        public override int GetHashCode() { return Id.GetHashCode(); }

        /*
         Evet, genelde her iki metoda da ihtiyaç vardır, çünkü:
         Framework ve Koleksiyonlar İçin:
         .NET koleksiyonlarının (HashSet, Dictionary, vb.) düzgün çalışabilmesi için Equals(object? obj) override edilmelidir.
         Tip Güvenliği ve Performans İçin:
         Projenizde Entity türünden nesneleri karşılaştırırken Equals(Entity? other) daha performanslı ve okunaklıdır.
         Equals(object? obj) metodunda, genel object türünden bir parametre aldığınız için parametrenin türünü kontrol etmek zorundasınız.
         */
        public bool Equals(Entity? other)
        {
            if (other is null) return false;

            if (other is not Entity entity) return false;

            if (other.GetType() != GetType()) return false;

            return entity.Id == Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;             
            if (obj is not Entity entity) return false; 
            if (obj.GetType() != GetType()) return false; 
            return entity.Id == Id; 
        }
    }
}
