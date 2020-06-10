﻿using AccountErp.Entities;
using AccountErp.Models.Invoice;
using AccountErp.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AccountErp.Factories
{
    public class InvoiceFactory
    {
        public static Invoice Create(InvoiceAddModel model, string userId)
        {
            
            var invoice = new Invoice
            {
                CustomerId = model.CustomerId,
                InvoiceNumber = string.Empty,
                Tax = model.Tax,
                Discount = model.Discount,
                TotalAmount = model.TotalAmount,
                Remark = model.Remark,
                Status = Constants.InvoiceStatus.Pending,
                CreatedBy = userId ?? "0",
                CreatedOn = Utility.GetDateTime(),
                InvoiceDate = model.InvoiceDate,
                StrInvoiceDate = model.InvoiceDate.ToString("yyyy-mm-dd"),
                DueDate = model.DueDate,
                StrDueDate = model.DueDate.ToString("yyyy-mm-dd"),
                PoSoNumber = model.PoSoNumber,
                Services = model.Items.Select(x => new InvoiceService
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
                return invoice;
            }

            foreach (var attachment in model.Attachments)
            {
                invoice.Attachments = new List<InvoiceAttachment>
                {
                    new InvoiceAttachment
                    {
                        Title = attachment.Title,
                        FileName = attachment.FileName,
                        OriginalFileName = attachment.OriginalFileName,
                        CreatedBy =userId ?? "0",
                        CreatedOn =Utility.GetDateTime()
                    }
                };
            }

            return invoice;
        }
        //public static Invoice Create(InvoiceAddModel model, string userId, List<Item> items)
        //{
        //    var invoice = new Invoice
        //    {
        //        CustomerId = model.CustomerId,
        //        InvoiceNumber = string.Empty,
        //        Tax = model.Tax,
        //        Discount = model.Discount,
        //        TotalAmount = model.TotalAmount,
        //        Remark = model.Remark,
        //        Status = Constants.InvoiceStatus.Pending,
        //        CreatedBy = userId,
        //        CreatedOn = Utility.GetDateTime(),
        //        Services = items.Select(x => new InvoiceService
        //        {
        //            Id = Guid.NewGuid(),
        //            ServiceId = x.Id,
        //            Rate = x.Rate
        //        }).ToList()
        //    };


        //    if (model.Attachments == null || !model.Attachments.Any())
        //    {
        //        return invoice;
        //    }

        //    foreach (var attachment in model.Attachments)
        //    {
        //        invoice.Attachments = new List<InvoiceAttachment>
        //        {
        //            new InvoiceAttachment
        //            {
        //                Title = attachment.Title,
        //                FileName = attachment.FileName,
        //                OriginalFileName = attachment.OriginalFileName,
        //                CreatedBy =userId,
        //                CreatedOn =Utility.GetDateTime()
        //            }
        //        };
        //    }

        //    return invoice;
        //}

        //public static void Create(InvoiceEditModel model, Invoice entity, string userId, List<Item> items)
        //{
        //    entity.CustomerId = model.CustomerId;
        //    entity.Tax = model.Tax;
        //    entity.Discount = model.Discount;
        //    entity.TotalAmount = model.TotalAmount;
        //    entity.Remark = model.Remark;
        //    entity.UpdatedBy = userId;
        //    entity.UpdatedOn = Utility.GetDateTime();

        //    var deletedServices = entity.Services.Where(x => !model.Items.Contains(x.ServiceId)).ToList();

        //    foreach (var deletedService in deletedServices)
        //    {
        //        entity.Services.Remove(deletedService);
        //    }

        //    var addedServices = items
        //        .Where(x => !entity.Services.Select(y => y.ServiceId).Contains(x.Id))
        //        .ToList();

        //    foreach (var service in addedServices)
        //    {
        //        entity.Services.Add(new InvoiceService
        //        {
        //            Id = Guid.NewGuid(),
        //            ServiceId = service.Id,
        //            Rate = service.Rate
        //        });
        //    }

        //    if (model.Attachments == null || !model.Attachments.Any())
        //    {
        //        return;
        //    }

        //    var deletedAttachemntFiles = entity.Attachments.Select(x => x.FileName)
        //        .Except(model.Attachments.Select(y => y.FileName)).ToList();

        //    foreach (var deletedAttachemntFile in deletedAttachemntFiles)
        //    {
        //        var attachemnt = entity.Attachments.Single(x => x.FileName.Equals(deletedAttachemntFile));
        //        entity.Attachments.Remove(attachemnt);
        //    }

        //    foreach (var attachment in model.Attachments)
        //    {
        //        var invoiceAttachment = entity.Attachments.SingleOrDefault(x => x.FileName.Equals(attachment.FileName));

        //        if (invoiceAttachment == null)
        //        {
        //            invoiceAttachment = new InvoiceAttachment
        //            {
        //                Title = attachment.Title,
        //                FileName = attachment.FileName,
        //                OriginalFileName = attachment.OriginalFileName,
        //                CreatedBy = userId,
        //                CreatedOn = Utility.GetDateTime()
        //            };
        //        }
        //        else
        //        {
        //            invoiceAttachment.Title = attachment.Title;
        //            invoiceAttachment.FileName = attachment.FileName;
        //            invoiceAttachment.OriginalFileName = attachment.OriginalFileName;
        //        }

        //        entity.Attachments.Add(invoiceAttachment);
        //    }
        //}


        public static void EditInvoice(InvoiceEditModel model, Invoice entity, string userId)
        {
            entity.CustomerId = model.CustomerId;
            entity.Tax = model.Tax;
            entity.Discount = model.Discount;
            entity.TotalAmount = model.TotalAmount;
            entity.Remark = model.Remark;
            entity.UpdatedBy = userId ?? "0";
            entity.UpdatedOn = Utility.GetDateTime();
            entity.InvoiceDate = model.InvoiceDate;
            entity.StrInvoiceDate = model.InvoiceDate.ToString("yyyy-mm-dd");
            entity.DueDate = model.DueDate;
            entity.StrDueDate = model.DueDate.ToString("yyyy-mm-dd");
            entity.PoSoNumber = model.PoSoNumber;

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
                entity.Services.Add(new InvoiceService
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
                    invoiceAttachment = new InvoiceAttachment
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
