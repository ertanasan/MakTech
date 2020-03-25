// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Warehouse;
using Overtech.ServiceContracts.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class ConsignmentGoodPurchaseService : CRUDLDataService<Overtech.DataModels.Warehouse.ConsignmentGoodPurchase>, IConsignmentGoodPurchaseService
    {
        /*Section="Constructor-1"*/
        public ConsignmentGoodPurchaseService()
        {
        }

        /*Section="Constructor-2"*/
        internal ConsignmentGoodPurchaseService(IDAL dal)
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