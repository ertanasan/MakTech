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
    public class StoreAccountsService : CRUDLDataService<Overtech.DataModels.Store.StoreAccounts>, IStoreAccountsService
    {
        /*Section="Constructor-1"*/
        public StoreAccountsService()
        {
        }

        /*Section="Constructor-2"*/
        internal StoreAccountsService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<StoreAccounts> ListStoreAccounts(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStore = dal.CreateParameter("Store", storeId);
                return dal.List<StoreAccounts>("STR_LST_ACCOUNTS_SP", prmStore).ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}