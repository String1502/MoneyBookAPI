using System;

namespace MoneyBookAPI.DTOs
{
    public class Transaction
    {
        public int Id { get; set; }
        public int WalletId { get; set; }
        public int TypeId { get; set; }
        public int? EventId { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool IsDeleted { get; set; }
    }

}