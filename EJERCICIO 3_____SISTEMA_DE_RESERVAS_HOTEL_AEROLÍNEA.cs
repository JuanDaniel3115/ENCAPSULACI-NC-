using ENCAPSULACIÓN.Value_Object;

namespace ENCAPSULACIÓN
{
    public class Reservation
    {
        public int Id { get; }
        public DateRange Period { get; }
        public Money TotalAmount { get; }
        public Money PaidAmount { get; private set; }
        public ReservationStatus Status { get; private set; }


        public Reservation(int id, DateRange period, Money totalAmount)
        {
            Id = id;
            Period = period;
            TotalAmount = totalAmount;
            PaidAmount = new Money(0.01m); // truco: evita cero
            Status = ReservationStatus.Created;

        }


        public void Confirm()
        {
            if (Status != ReservationStatus.Created)
                throw new InvalidOperationException("Reservation cannot be confirmed");

            Status = ReservationStatus.Confirmed;
        }
        public void Pay(Money amount)
        {
            EnsureConfirmed();

            PaidAmount = PaidAmount.Add(amount);

            if (PaidAmount.Amount > TotalAmount.Amount)
                throw new InvalidOperationException("Payment exceeds total amount");

            if (PaidAmount.Amount == TotalAmount.Amount)
                Status = ReservationStatus.Completed;
        }
        public void Cancel()
        {
            EnsureConfirmed();
            Status = ReservationStatus.Cancelled;
        }

        private void EnsureConfirmed()
        {
            if (Status != ReservationStatus.Confirmed)
                throw new InvalidOperationException("Reservation is not confirmed");
        }

        public enum ReservationStatus
        {
            Created = 1,
            Confirmed = 2,
            Cancelled = 3,
            Completed = 4,
            Free = 5
        }

    }
}
