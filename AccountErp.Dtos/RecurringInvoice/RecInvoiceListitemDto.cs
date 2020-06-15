﻿using AccountErp.Dtos.Customer;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.RecurringInvoice
{
    public class RecInvoiceListitemDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remark { get; set; }
        public DateTime RecInvoiceDate { get; set; }
        public DateTime RecDueDate { get; set; }
        public decimal? PoSoNumber { get; set; }
        public string StrRecInvoiceDate { get; set; }
        public string StrRecDueDate { get; set; }
        public Constants.InvoiceStatus Status { get; set; }
    }
}