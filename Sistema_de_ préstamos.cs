using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ENCAPSULACIÓN
{
    public class Loan
    {
        public int Id { get; }
        public decimal Amount { get; private set; }
        public DateTime DueDate { get; private set; }
        public LoanStatus Status { get; private set; }


        public Loan(int id)
        {
            Id = id;
            Status = LoanStatus.Unapproved;
            Amount = 0;
        }

        public void Approve(decimal amount, DateTime dueDate)
        {
            if (Status != LoanStatus.Unapproved)
                throw new InvalidOperationException("Loan already approved");

            if (amount <= 0)
                throw new ArgumentException("Amount must be positive");

            if (dueDate <= DateTime.UtcNow)
                throw new ArgumentException("Due date must be in the future");

            Amount = amount;
            DueDate = dueDate;
            Status = LoanStatus.Approved;
        }

        public void Pay(decimal amount)
        {
            EnsureApproved();

            if (amount <= 0)
                throw new ArgumentException("Payment must be positive");

            if (amount > Amount)
                throw new InvalidOperationException("Payment exceeds remaining balance");

            Amount -= amount;

            if (Amount == 0)
                Status = LoanStatus.Paid;
        }

        private void EnsureApproved()
        {
            if (Status != LoanStatus.Approved)
                throw new InvalidOperationException("Loan is not approved");
        }



    }
    public enum LoanStatus
    {
        Unapproved = 1,
        Approved = 2,
        Paid = 3
    }
}
