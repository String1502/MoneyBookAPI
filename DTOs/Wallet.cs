using System;

namespace MoneyBookAPI.DTOs
{
    public class Wallet
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public int AccountId { get; set; }
        public int IconId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool IsDeleted { get; set; }
    }

}