// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Accounting;
using Overtech.ServiceContracts.Accounting;

/*Section="ClassHeader"*/
namespace Overtech.Services.Accounting
{
    [OTInspectorBehavior]
    public class ExpenseCenterService : CRUDLDataService<Overtech.DataModels.Accounting.ExpenseCenter>, IExpenseCenterService
    {
        /*Section="Constructor-1"*/
        public ExpenseCenterService()
        {
        }

        /*Section="Constructor-2"*/
        internal ExpenseCenterService(IDAL dal)
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