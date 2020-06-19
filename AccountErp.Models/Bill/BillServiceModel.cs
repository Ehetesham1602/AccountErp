﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Models.Bill
{
    public class BillServiceModel
    {
        public int ItemId { get; set; }
        public decimal Rate { get; set; }
        public decimal Price { get; set; }
        public int TaxId { get; set; }
        public int? TaxPercentage { get; set; }
        public int Quantity { get; set; }
    }
}