using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyBookAPI.DTOs
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool IsDeleted { get; set; }
    }
}