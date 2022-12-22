using System;

namespace MoneyBookAPI.DTOs
{
    public class Event
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int IconId { get; set; }
        public string Name { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool IsDeleted { get; set; }
    }

}