using AccountErp.Entities;
using AccountErp.Models.Reconciliation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Factories
{
    public class ReconciliationFactory
    {
        public static Reconciliation Create(ReconciliationAddModel model, string userId)
        {
            var reconciliation = new Reconciliation
            {

                BankAccountId = model.BankAccountId,
                ReconciliationDate = model.ReconciliationDate,
                StartingBalance = model.StartingBalance,
                EndingBalance = model.EndingBalance,
                ReconciliationStatus = model.ReconciliationStatus,
                IsReconciliation = model.IsReconciliation

            };
            return reconciliation;
        }
        public static void Create(ReconciliationEditModel model, Reconciliation entity, string userId)
        {
            entity.BankAccountId = model.BankAccountId;
            entity.ReconciliationDate = model.ReconciliationDate;
            entity.StartingBalance = model.StartingBalance;
            entity.EndingBalance = model.EndingBalance;
            entity.ReconciliationStatus = model.ReconciliationStatus;
                entity.IsReconciliation = model.IsReconciliation;


    }

    }
}

