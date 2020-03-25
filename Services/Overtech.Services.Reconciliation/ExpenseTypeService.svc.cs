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
    public class ExpenseTypeService : CRUDLDataService<Overtech.DataModels.Reconciliation.ExpenseType>, IExpenseTypeService
    {
        /*Section="Constructor-1"*/
        public ExpenseTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal ExpenseTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Reconciliation.ExpenseType Find(string expenseTypeName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmExpenseTypeName = dal.CreateParameter("ExpenseTypeName", expenseTypeName);
                return dal.Read<Overtech.DataModels.Reconciliation.ExpenseType>("RCL_SEL_FINDEXPENSETYPE_SP", prmExpenseTypeName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}