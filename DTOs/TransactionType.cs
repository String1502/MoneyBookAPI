using System;

namespace MoneyBookAPI.DTOs
{
    public class TransactionType
    {
        public int Id { get; set; }
        public int IconId { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public bool IsExpense { get; set; }
        public bool IsDefault { get; set; }
        public string Tag { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool IsDeleted { get; set; }
    }

}