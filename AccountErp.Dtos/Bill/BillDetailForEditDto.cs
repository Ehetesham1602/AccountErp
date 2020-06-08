using System.Collections.Generic;

namespace AccountErp.Dtos.Bill
{
    public class BillDetailForEditDto
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal? Tax { get; set; }
        public decimal TotalAmount { get; set; }
        public string Remark { get; set; }
        public decimal? Discount { get; set; }

        public IEnumerable<int> Items { get; set; }
        public IEnumerable<BillAttachmentDto> Attachments { get; set; }
    }
}
