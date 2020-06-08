﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Models.Invoice
{
    public class InvoiceServiceModel
    {
        public int ServiceId { get; set; }
        public decimal Rate { get; set; }
        public decimal Price { get; set; }
        public int TaxId { get; set; }
        public decimal TaxPrice { get; set; }

        public int Quantity { get; set; }
    }
}
