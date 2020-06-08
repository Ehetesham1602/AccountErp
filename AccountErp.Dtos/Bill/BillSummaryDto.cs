namespace AccountErp.Dtos.Bill
{
    public class BillSummaryDto
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Description { get; set; }
    }
}
