using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENCAPSULACIÓN.Value_Object
{
    public sealed class Money
    {
        public decimal Amount { get; }


        public Money (decimal amount)
        {
            if(amount < 0)
                throw new ArgumentException("Amount must be positive");
            Amount = amount;
        }

        public Money Add(Money other)
            => new Money(Amount + other.Amount);

        public Money Subtract(Money other)
        {
            if(other.Amount > Amount)
                throw new InvalidOperationException("Insufficient amount");
            return new Money(Amount - other.Amount);
        }

        public override bool Equals(object? obj)
            => obj is Money other && Amount == other.Amount;

        public override int GetHashCode()
            => Amount.GetHashCode();

    }

    public sealed class DateRange
    {
        public DateTime Start { get; }
        public DateTime End { get; }

        public DateRange(DateTime start, DateTime end)
        {
            if (end <= start)
                throw new ArgumentException("End date must be after start date");

            if (start <= DateTime.UtcNow)
                throw new ArgumentException("Start date must be in the future");

            Start = start;
            End = end;
        }

        public bool IsActive(DateTime date)
            => date >= Start && date <= End;
    }

}
