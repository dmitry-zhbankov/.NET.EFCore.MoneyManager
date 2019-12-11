using System;

namespace Money_Manager.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string Comment { get; set; }

        public Category Category { get; set; }

        public Asset Source { get; set; }

        public Asset Destination { get; set; }

        public DateTime Date { get; set; }
    }
}
