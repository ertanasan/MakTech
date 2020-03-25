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
    public class StoreCashRegisterService : CRUDLDataService<Overtech.DataModels.Store.StoreCashRegister>, IStoreCashRegisterService
    {
        /*Section="Constructor-1"*/
        public StoreCashRegisterService()
        {
        }

        /*Section="Constructor-2"*/
        internal StoreCashRegisterService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<StoreCashRegister> StoreCashRegisters(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmPackage = dal.CreateParameter("Store", storeId);
                return dal.List<StoreCashRegister>("STR_LST_CASHREGISTER_SP", prmPackage).ToList();
            }
        }

        public IEnumerable<StoreCashRegister> GetUserCashRegister()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<StoreCashRegister>("STR_LST_USERCASHREGISTER_SP").ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}