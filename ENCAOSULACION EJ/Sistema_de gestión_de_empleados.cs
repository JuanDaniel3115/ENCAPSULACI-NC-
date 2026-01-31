namespace ENCAPSULACIÓN
{
    public class Employee
    {
        public int Id { get; }
        public decimal Salary { get; private set; }
        public EmployeeStatus Status { get; private set; }

        public Employee(int id)
        {
            Id = id;
            Status = EmployeeStatus.Created;
        }

        public void Hire(decimal salary)
        {
            if (Status != EmployeeStatus.Created)
                throw new InvalidOperationException("Employee already hired");

            if (salary <= 0)
                throw new ArgumentException("Salary must be positive");

            Salary = salary;
            Status = EmployeeStatus.Active;
        }

        public void IncreaseSalary(decimal amount)
        {
            EnsureActive();

            if (amount <= 0)
                throw new ArgumentException("Amount must be positive");

            Salary += amount;
        }

        public void DecreaseSalary(decimal amount)
        {
            EnsureActive();

            if (amount <= 0)
                throw new ArgumentException("Amount must be positive");

            if (Salary - amount <= 0)
                throw new InvalidOperationException("Salary cannot be zero or negative");

            Salary -= amount;
        }

        public void Suspend()
        {
            EnsureActive();
            Status = EmployeeStatus.Suspended;
        }

        public void Activate()
        {
            if (Status != EmployeeStatus.Suspended)
                throw new InvalidOperationException("Only suspended employees can be activated");

            Status = EmployeeStatus.Active;
        }

        public void Terminate()
        {
            if (Status == EmployeeStatus.Terminated)
                throw new InvalidOperationException("Employee already terminated");

            Status = EmployeeStatus.Terminated;
        }

        private void EnsureActive()
        {
            if (Status != EmployeeStatus.Active)
                throw new InvalidOperationException("Employee is not active");
        }
    }

    public enum EmployeeStatus
    {
        Created = 1,
        Active = 2,
        Suspended = 3,
        Terminated = 4
    }

}
