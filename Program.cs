// See https://aka.ms/new-console-template for more information


using ENCAPSULACIÓN;

// Factura 1 - Flujo correcto
//Invoice invoice1 = new Invoice(1);
//invoice1.AddItem(100);
//invoice1.AddItem(300);
//invoice1.Close();
//Console.WriteLine($"Factura {invoice1.Id}: Total = {invoice1.Total}, Estado = {invoice1.Status}");

//// Factura 2 - Esto lanzará una excepción




//try
//{
//    Invoice invoice2 = new Invoice(21);
//    invoice2.AddItem(-22); // Error: El monto es negativo
//    invoice2.Close();
//    Console.WriteLine($"Factura {invoice2.Id}: Total = {invoice2.Total}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error en Factura 2: {ex.Message}");
//}

//#  Ejercicio 1

// Préstamo 1 - Flujo correcto
//Loan loan1 = new Loan(1);
//loan1.Approve(5000, DateTime.Now.AddMonths(6));

//loan1.Pay(1000);
//Console.WriteLine($"Préstamo {loan1.Id}:  Monto restante = {loan1.Amount}, Estado = {loan1.Status}");

//// Préstamo 2 - Esto lanzará una excepción
//try
//{
//    Loan loan2 = new Loan(202);
//    loan2.Pay(500); // Error: El préstamo no está aprobado
//    Console.WriteLine($"Préstamo {loan2.Id}: Monto restante = {loan2.Amount}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error en Préstamo 2: {ex.Message}");
//}

//# Ejercicio 2

// Empleado 1 - Flujo correcto
//Employee employee1 = new Employee(1);
//employee1.Hire(3000);
//employee1.IncreaseSalary(500);
//employee1.DecreaseSalary(400);
//employee1.Suspend();
//employee1.Activate();
//employee1.Terminate();
//Console.WriteLine($"Empleado {employee1.Id}: Salario = {employee1.Salary}, Estado = {employee1.Status}");
//// Empleado 2 - Esto lanzará una excepción
//Employee employee2 = new Employee(2);
//try
//{
//    employee2.DecreaseSalary(200); // Error: El empleado no está activo
//    Console.WriteLine($"Empleado {employee2.Id}: Salario = {employee2.Salary}");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error en Empleado 2: {ex.Message}");
//}


//# Ejercicio 3
// Reserva 1 - Flujo correcto
//Reservation reservation1 = new Reservation(1, 1000);
//reservation1.Create(DateTime.UtcNow.AddDays(1), DateTime.UtcNow.AddDays(5), 500);
//reservation1.Confirm();
//reservation1.Complete(500);
//Console.WriteLine($"Reserva {reservation1.Id}: Saldo a Pagar = {reservation1.TotalAmount}, Estado = {reservation1.Status}");
//// Reserva 2 - Esto Cancela la reserva
//Reservation reservation2 = new Reservation(2, 800);
//reservation2.Create(DateTime.UtcNow.AddDays(2), DateTime.UtcNow.AddDays(6), 300);
//reservation2.Confirm();
//reservation2.Cancel();
//Console.WriteLine($"Reserva {reservation2.Id}: Saldo a Pagar = {reservation2.TotalAmount}, Estado = {reservation2.Status}");


Console.WriteLine("Presiona cualquier tecla para salir...");
Console.ReadKey();