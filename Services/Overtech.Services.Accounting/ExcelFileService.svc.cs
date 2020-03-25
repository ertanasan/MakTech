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
    public class ExcelFileService : CRUDLDataService<Overtech.DataModels.Accounting.ExcelFile>, IExcelFileService
    {
        /*Section="Constructor-1"*/
        public ExcelFileService()
        {
        }

        /*Section="Constructor-2"*/
        internal ExcelFileService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-ListExcelFileColumnss"*/
        public IEnumerable<ExcelFileColumns> ListExcelFileColumnss(long excelFileId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmExcelFile = dal.CreateParameter("ExcelFile", excelFileId);
                return dal.List<ExcelFileColumns>("ACC_LST_EXCELFILECOLUMNS_SP", prmExcelFile).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}