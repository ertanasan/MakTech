// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Reconciliation;
using Overtech.ServiceContracts.Reconciliation;

/*Section="ClassHeader"*/
namespace Overtech.Services.Reconciliation
{
    [OTInspectorBehavior]
    public class BanknoteService : CRUDLDataService<Overtech.DataModels.Reconciliation.Banknote>, IBanknoteService
    {
        /*Section="Constructor-1"*/
        public BanknoteService()
        {
        }

        /*Section="Constructor-2"*/
        internal BanknoteService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}