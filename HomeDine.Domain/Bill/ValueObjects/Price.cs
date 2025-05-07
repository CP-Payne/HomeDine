using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDine.Domain.Common.Models;

namespace HomeDine.Domain.Bill.ValueObjects
{
    public sealed class Price : ValueObject
    {
        public decimal Amount { get; }
        public string Currency { get; }

        private Price(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public static Price Create(decimal amount, string currency)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    "Price amount cannot be negative."
                );
            }
            if (string.IsNullOrWhiteSpace(currency))
            {
                throw new ArgumentException(
                    "Currency cannot be null or whitespace.",
                    nameof(currency)
                );
            }
            if (currency.Length != 3 || !currency.All(char.IsUpper))
            {
                throw new ArgumentException(
                    "Currency must be a 3-letter uppercase ISO code (e.g., USD).",
                    nameof(currency)
                );
            }

            return new Price(amount, currency);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency.ToUpperInvariant();
        }

        public override string ToString()
        {
            return $"{Amount:0.00} {Currency}";
        }
    }
}
