using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDriventDesign.Domain.Shared
{
    public sealed record Currency
    {
        internal static readonly Currency None = new Currency("");
        private static readonly Currency Usd = new Currency("Usd");
        private static readonly Currency TRY = new Currency("TRY");

        public string Code { get; init; }

        private Currency(string code)
        {
            Code = code;
        }

        public static Currency FromCode(string code)
        {
            return All.FirstOrDefault<Currency>(p => p.Code == code) ?? throw new ArgumentException("Geçerli bir para birimi giriniz!");
        }

        public static readonly IReadOnlyCollection<Currency> All = new[] { Usd, TRY};
    }
}
