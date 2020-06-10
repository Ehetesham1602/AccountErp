using AccountErp.Entities;
using AccountErp.Models.Quotation;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace AccountErp.Factories
{
    public class QuotationFactory
    {
        public static Quotation Create(QuotationAddModel model, string userId)
        {

            var quotation = new Quotation
            {
                CustomerId = model.CustomerId,
                QuotationNumber = string.Empty,
                Tax = model.Tax,
                Discount = model.Discount,
                TotalAmount = model.TotalAmount,
                Remark = model.Remark,
                Status = Constants.InvoiceStatus.Pending,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                QuotationDate = model.QuotationDate,
                StrQuotationDate = model.QuotationDate.ToString("yyyy-mm-dd"),
                ExpireDate = model.ExpiryDate,
                StrExpireDate = model.ExpiryDate.ToString("yyyy-mm-dd"),
                PoSoNumber = model.PoSoNumber,
                Memo = model.Memo,
                Services = model.Items.Select(x => new QuotationService
                {
                    Id = Guid.NewGuid(),
                    ServiceId = x.ServiceId,
                    Rate = x.Rate,
                    Quantity = x.Quantity,
                    Price = x.Price,
                    TaxId = x.TaxId,
                    TaxPrice = x.TaxPrice,
                    TaxPercentage = x.TaxPercentage
                }).ToList()
            };


            if (model.Attachments == null || !model.Attachments.Any())
            {
                return quotation;
            }

            foreach (var attachment in model.Attachments)
            {
                quotation.Attachments = new List<QuotationAttachment>
                {
                    new QuotationAttachment
                    {
                        Title = attachment.Title,
                        FileName = attachment.FileName,
                        OriginalFileName = attachment.OriginalFileName,
                        CreatedBy =userId ?? "0",
                        CreatedOn =Utility.GetDateTime()
                    }
                };
            }

            return quotation;
        }

        public static void EditInvoice(QuotationEditModel model, Quotation entity, string userId)
        {
            entity.CustomerId = model.CustomerId;
            entity.Tax = model.Tax;
            entity.Discount = model.Discount;
            entity.TotalAmount = model.TotalAmount;
            entity.Remark = model.Remark;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            entity.QuotationDate = model.QuotationDate;
            entity.StrQuotationDate = model.QuotationDate.ToString("yyyy-mm-dd");
            entity.ExpireDate = model.ExpiryDate;
            entity.StrExpireDate = model.ExpiryDate.ToString("yyyy-mm-dd");
            entity.PoSoNumber = model.PoSoNumber;
            entity.Memo = model.Memo;

            //int[] arr = new int[100];
            ArrayList tempArr = new ArrayList();

            //for (int i=0;i<model.Items.Count; i++)
            //{
            //    arr[i] = model.Items[i].ServiceId;
            //}

            foreach (var item in model.Items)
            {
                tempArr.Add(item.ServiceId);
            }

            var deletedServices = entity.Services.Where(x => !tempArr.Contains(x.ServiceId)).ToList();
            //var resultAll = items.Where(i => filter.All(x => i.Features.Any(f => x == f.Id)));

            foreach (var deletedService in deletedServices)
            {
                entity.Services.Remove(deletedService);
            }

            //var addedServices = items
            //    .Where(x => !entity.Services.Select(y => y.ServiceId).Contains(x.Id))
            //    .ToList();

            foreach (var service in model.Items)
            {
                entity.Services.Add(new QuotationService
                {
                    Id = Guid.NewGuid(),
                    ServiceId = service.ServiceId,
                    Rate = service.Rate,
                    TaxId = service.TaxId,
                    Price = service.Price,
                    TaxPrice = service.TaxPrice,
                    Quantity = service.Quantity,
                    TaxPercentage = service.TaxPercentage
                });
            }

            if (model.Attachments == null || !model.Attachments.Any())
            {
                return;
            }

            var deletedAttachemntFiles = entity.Attachments.Select(x => x.FileName)
                .Except(model.Attachments.Select(y => y.FileName)).ToList();

            foreach (var deletedAttachemntFile in deletedAttachemntFiles)
            {
                var attachemnt = entity.Attachments.Single(x => x.FileName.Equals(deletedAttachemntFile));
                entity.Attachments.Remove(attachemnt);
            }

            foreach (var attachment in model.Attachments)
            {
                var invoiceAttachment = entity.Attachments.SingleOrDefault(x => x.FileName.Equals(attachment.FileName));

                if (invoiceAttachment == null)
                {
                    invoiceAttachment = new QuotationAttachment
                    {
                        Title = attachment.Title,
                        FileName = attachment.FileName,
                        OriginalFileName = attachment.OriginalFileName,
                        CreatedBy = userId ?? "0",
                        CreatedOn = Utility.GetDateTime()
                    };
                }
                else
                {
                    invoiceAttachment.Title = attachment.Title;
                    invoiceAttachment.FileName = attachment.FileName;
                    invoiceAttachment.OriginalFileName = attachment.OriginalFileName;
                }

                entity.Attachments.Add(invoiceAttachment);
            }
        }
    }
}
