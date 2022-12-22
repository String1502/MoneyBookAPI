using System;

namespace MoneyBookAPI.DTOs
{
    public class Acquaintance
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool IsDeleted { get; set; }
    }

}