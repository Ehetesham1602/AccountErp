using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountErp.Models.Bill
{
    public class BillAddModel
    {
        [Required]
        public int VendorId { get; set; }
        public decimal? Tax { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? DueDate { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public string Remark { get; set; }
        [Required]
        public List<int> Items { get; set; }
        public IList<BillAttachmentModel> Attachments { get; set; }
    }
}
