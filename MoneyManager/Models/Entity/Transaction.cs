using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyManager.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        [Required] public decimal Amount { get; set; }

        public string Comment { get; set; }

        [Required] public User User { get; set; }

        [Required] public Category Category { get; set; }

        [Required] public Asset Asset { get; set; }

        [Required] public DateTime Date { get; set; }
    }
}