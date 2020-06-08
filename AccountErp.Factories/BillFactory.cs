using AccountErp.Entities;
using AccountErp.Models.Bill;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountErp.Factories
{
    public class BillFactory
    {
        public static Bill Create(BillAddModel model, string userId, List<Item> items)
        {
            var bill = new Bill
            {
                VendorId = model.VendorId,
                Tax = model.Tax,
                Discount = model.Discount,
                DueDate = model.DueDate,
                TotalAmount = model.TotalAmount,
                Remark = model.Remark,
                Status = Constants.BillStatus.Pending,
                CreatedBy = userId,
                CreatedOn = Utility.GetDateTime(),
                Items = items.Select(x => new BillItem
                {
                    Id = Guid.NewGuid(),
                    ItemId = x.Id,
                    Rate = x.Rate
                }).ToList()
            };

            if (model.Attachments == null || !model.Attachments.Any())
            {
                return bill;
            }

            bill.Attachments = new List<BillAttachment>();

            foreach (var attachment in model.Attachments)
            {
                bill.Attachments = new List<BillAttachment>
                {
                    new BillAttachment
                    {
                        Title = attachment.Title,
                        FileName = attachment.FileName,
                        OriginalFileName = attachment.OriginalFileName,
                        CreatedBy =userId,
                        CreatedOn =Utility.GetDateTime()
                    }
                };
            }

            return bill;
        }

        public static void Edit(Bill bill, BillEditModel model, string userId, List<Item> items)
        {
            bill.VendorId = model.VendorId;
            bill.Tax = model.Tax;
            bill.Discount = model.Discount;
            bill.TotalAmount = model.TotalAmount;
            bill.Remark = model.Remark;
            bill.DueDate = model.DueDate;
            bill.UpdatedBy = userId;
            bill.UpdatedOn = Utility.GetDateTime();

            var deletedServices = bill.Items.Where(x => !model.Items.Contains(x.ItemId)).ToList();

            foreach (var deletedService in deletedServices)
            {
                bill.Items.Remove(deletedService);
            }

            var addedServices = items
                .Where(x => !bill.Items.Select(y => y.ItemId).Contains(x.Id))
                .ToList();

            foreach (var service in addedServices)
            {
                bill.Items.Add(new BillItem
                {
                    Id = Guid.NewGuid(),
                    ItemId = service.Id,
                    Rate = service.Rate
                });
            }

            if (model.Attachments == null || !model.Attachments.Any())
            {
                return;
            }

            var deletedAttachemntFiles = bill.Attachments.Select(x => x.FileName)
                .Except(model.Attachments.Select(y => y.FileName)).ToList();

            foreach (var deletedAttachemntFile in deletedAttachemntFiles)
            {
                var attachemnt = bill.Attachments.Single(x => x.FileName.Equals(deletedAttachemntFile));
                bill.Attachments.Remove(attachemnt);
            }

            foreach (var attachment in model.Attachments)
            {
                var billAttachment = bill.Attachments.SingleOrDefault(x => x.FileName.Equals(attachment.FileName));

                if (billAttachment == null)
                {
                    billAttachment = new BillAttachment
                    {
                        Title = attachment.Title,
                        FileName = attachment.FileName,
                        OriginalFileName = attachment.OriginalFileName,
                        CreatedBy = userId,
                        CreatedOn = Utility.GetDateTime()
                    };
                }
                else
                {
                    billAttachment.Title = attachment.Title;
                    billAttachment.FileName = attachment.FileName;
                    billAttachment.OriginalFileName = attachment.OriginalFileName;
                }

                bill.Attachments.Add(billAttachment);
            }
        }
    }
}
