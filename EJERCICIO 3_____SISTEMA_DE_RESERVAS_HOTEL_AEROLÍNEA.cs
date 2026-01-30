namespace ENCAPSULACIÓN
{
    public class Reservation
    {
        public int Id { get; }
        public decimal TotalAmount { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public ReservationStatus Status { get; private set; }

        public Reservation(int id, decimal amount)
        {
            Id = id;
            Status = ReservationStatus.Free;
            TotalAmount = amount;
        }

        public void Create(DateTime startDate, DateTime endDate, decimal amount)
        {
            if (Status != ReservationStatus.Free)
                throw new InvalidOperationException("Reservation already created");
            ValidateReservation(startDate, endDate);

            if (amount <= 0)
                throw new ArgumentException("Amount must be positive");

            StartDate = startDate;
            EndDate = endDate;
            TotalAmount -= amount;
            Status = ReservationStatus.Created;
        }
        public void Confirm()
        {
            if (Status != ReservationStatus.Created)
                throw new InvalidOperationException("Reservation not in created status");

            Status = ReservationStatus.Confirmed;
        }
        public void Cancel()
        {
            EnsureConfirmed();
            Status = ReservationStatus.Cancelled;
        }
        public void Complete(decimal totalAmount)
        {
            EnsureConfirmed();
            if(totalAmount-TotalAmount != 0)
                throw new InvalidOperationException("Total amount does not match");
            Status = ReservationStatus.Completed;
            TotalAmount -= totalAmount;
        }


        private void EnsureConfirmed()
        {
            if (Status != ReservationStatus.Confirmed)
                throw new InvalidOperationException("Reservation is not confirmed");
        }

        private static void ValidateReservation(DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
                throw new InvalidOperationException("End date must be after start date");
            if (startDate < DateTime.UtcNow.AddMinutes(-1))
                throw new InvalidOperationException("Start date must be in the future");
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
