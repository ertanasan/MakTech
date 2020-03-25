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
    public class TransactionTypeService : CRUDLDataService<Overtech.DataModels.Sale.TransactionType>, ITransactionTypeService
    {
        /*Section="Constructor-1"*/
        public TransactionTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal TransactionTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Sale.TransactionType Find(string transactionName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmTransactionName = dal.CreateParameter("TransactionName", transactionName);
                return dal.Read<Overtech.DataModels.Sale.TransactionType>("SLS_SEL_FINDTRANSACTIONTYPE_SP", prmTransactionName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}