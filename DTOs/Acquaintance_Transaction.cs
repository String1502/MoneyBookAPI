using System;

namespace MoneyBookAPI.DTOs
{
    public class Acquaintance_Transaction
    {
        public int Id { get; set; }
        public int AcquaintanceId { get; set; }
        public int TransactionId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool IsDeleted { get; set; }
    }

}