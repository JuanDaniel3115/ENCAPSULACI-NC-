using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENCAPSULACIÓN
{

    /**
     *   Encapsular =
        👉 Proteger el estado
        👉 Exponer comportamiento
        👉 Controlar invariantes
    **/
        /**
         * Contexto
         * Sistema de facturación
            Una factura:
            - No puede tener total negativo
            - No puede cambiarse si está cerrada
        **/
    public class Invoice
    {

        public int Id { get; }
        public decimal Total { get; private set; }
        public InvoiceStatus Status { get; private set; }

        public Invoice(int id)
        {
            Id = id;
            Status = InvoiceStatus.Open;
            Total = 0;
        }

        public void AddItem(decimal amount)
        {
            if(Status == InvoiceStatus.Closed)
                throw new InvalidOperationException("Invoice is close");

            if(amount <= 0)
                throw new ArgumentException("Amount must be positive");
            Total += amount;
        }
        public void Close()
        {
            if (Total == 0)
                throw new InvalidOperationException("Cannot close empty invoice");
            Status = InvoiceStatus.Closed;
        }

    }

    public enum InvoiceStatus
    {
        Open = 1,
        Closed = 2
    }

}
