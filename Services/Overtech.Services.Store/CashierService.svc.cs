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
    public class CashierService : CRUDLDataService<Overtech.DataModels.Store.Cashier>, ICashierService
    {
        /*Section="Constructor-1"*/
        public CashierService()
        {
        }

        /*Section="Constructor-2"*/
        internal CashierService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<Cashier> StoreCashiers(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStore = dal.CreateParameter("StoreId", storeId);
                return dal.List<Cashier>("STR_LST_STORECASHIER_SP", prmStore).ToList();
            }
        }

        public override Cashier Create(Cashier dataObject)
        {
            return base.Create(dataObject);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}