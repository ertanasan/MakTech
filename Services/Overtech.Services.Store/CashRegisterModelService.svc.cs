// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Store;
using Overtech.ServiceContracts.Store;

/*Section="ClassHeader"*/
namespace Overtech.Services.Store
{
    [OTInspectorBehavior]
    public class CashRegisterModelService : CRUDLDataService<Overtech.DataModels.Store.CashRegisterModel>, ICashRegisterModelService
    {
        /*Section="Constructor-1"*/
        public CashRegisterModelService()
        {
        }

        /*Section="Constructor-2"*/
        internal CashRegisterModelService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Store.CashRegisterModel Find(string name)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmName = dal.CreateParameter("Name", name);
                return dal.Read<Overtech.DataModels.Store.CashRegisterModel>("STR_SEL_FINDCASHREGISTERMODEL_SP", prmName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}