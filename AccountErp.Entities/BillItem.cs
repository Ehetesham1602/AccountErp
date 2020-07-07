using System;

namespace AccountErp.Entities
{
    public class BillItem
    {
        public Guid Id { get; set; }
        public int BillId { get; set; }
        public int ItemId { get; set; }
        public decimal Rate { get; set; }
        public decimal Price { get; set; }
        public int TaxId { get; set; }
        public int? TaxPercentage { get; set; }
        public int Quantity { get; set; }
        public Item Item { get; set; }
    }
}
