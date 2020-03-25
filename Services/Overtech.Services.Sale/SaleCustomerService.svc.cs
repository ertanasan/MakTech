// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Sale;
using Overtech.ServiceContracts.Sale;

/*Section="ClassHeader"*/
namespace Overtech.Services.Sale
{
    [OTInspectorBehavior]
    public class SaleCustomerService : CRUDLDataService<Overtech.DataModels.Sale.SaleCustomer>, ISaleCustomerService
    {
        /*Section="Constructor-1"*/
        public SaleCustomerService()
        {
        }

        /*Section="Constructor-2"*/
        internal SaleCustomerService(IDAL dal)
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