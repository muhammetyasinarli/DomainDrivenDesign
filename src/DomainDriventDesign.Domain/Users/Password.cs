namespace DomainDriventDesign.Domain.Users
{
    public sealed record Password
    {
        public string Value { get; init; }

        public Password(string value)
        {
            Value = value;
        }
    }
}
