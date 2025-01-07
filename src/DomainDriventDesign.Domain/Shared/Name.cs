namespace DomainDriventDesign.Domain.Shared
{
    public sealed record Name
    {
        public string Value { get; init; }

        public Name(string value)
        {
            if (string.IsNullOrEmpty(value)) { throw new ArgumentNullException(nameof(value)); }

            if (value.Length < 3)
            {
                throw new ArgumentException("isim alanı 3 karakterden küçük olamaz");
            }

            Value = value;
        }
    }
}
