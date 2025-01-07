namespace DomainDriventDesign.Domain.Users
{
    public sealed record Email
    {
        public string Value { get; init; }

        public Email(string value)
        {
            Value = value;
        }
    }
}
