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
    public class ExcelFileColumnsService : CRUDLDataService<Overtech.DataModels.Accounting.ExcelFileColumns>, IExcelFileColumnsService
    {
        /*Section="Constructor-1"*/
        public ExcelFileColumnsService()
        {
        }

        /*Section="Constructor-2"*/
        internal ExcelFileColumnsService(IDAL dal)
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