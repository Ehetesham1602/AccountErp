﻿using System;

namespace AccountErp.Entities
{
    public class InvoiceService
    {
        public Guid Id { get; set; }
        public int InvoiceId { get; set; }
        public int ServiceId { get; set; }
        public decimal Rate { get; set; }
        public decimal Price { get; set; }
        public int TaxId { get; set; }
        public decimal TaxPrice { get; set; }
        public int? TaxPercentage { get; set; }

        public int Quantity { get; set; }

        public Item Service { get; set; }
    }
}
