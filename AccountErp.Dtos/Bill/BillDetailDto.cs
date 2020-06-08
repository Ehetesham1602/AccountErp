using AccountErp.Dtos.Vendor;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;

namespace AccountErp.Dtos.Bill
{
    public class BillDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal? Tax { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal? Discount { get; set; }
        public string Remark { get; set; }
        public Constants.BillStatus Status { get; set; }
        public DateTime CreatedOn { get; set; }

        public VendorPersonallnfoDto Vendor { get; set; }

        public IEnumerable<BillServiceDto> Items { get; set; }
        public IEnumerable<BillAttachmentDto> Attachments { get; set; }
    }
}
