using System;
using System.Collections.Generic;

namespace BillsProvidersServices.Models
{
    public partial class Bills
    {
        public Guid IdBill { get; set; }
        public Guid IdProvider { get; set; }
        public Guid IdProduct { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
    }
}
