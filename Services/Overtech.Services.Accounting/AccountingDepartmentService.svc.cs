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
    public class AccountingDepartmentService : CRUDLDataService<Overtech.DataModels.Accounting.AccountingDepartment>, IAccountingDepartmentService
    {
        /*Section="Constructor-1"*/
        public AccountingDepartmentService()
        {
        }

        /*Section="Constructor-2"*/
        internal AccountingDepartmentService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Accounting.AccountingDepartment Find(string departmentName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmDepartmentName = dal.CreateParameter("DepartmentName", departmentName);
                return dal.Read<Overtech.DataModels.Accounting.AccountingDepartment>("ACC_SEL_FINDDEPARTMENT_SP", prmDepartmentName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}