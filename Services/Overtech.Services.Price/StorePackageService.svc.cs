// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Price;
using Overtech.DataModels.Store;
using Overtech.ServiceContracts.Price;

/*Section="ClassHeader"*/
namespace Overtech.Services.Price
{
    [OTInspectorBehavior]
    public class StorePackageService : CRUDLDataService<Overtech.DataModels.Price.StorePackage>, IStorePackageService
    {
        /*Section="Constructor-1"*/
        public StorePackageService()
        {
        }

        /*Section="Constructor-2"*/
        internal StorePackageService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public void CreateStorePackage(StorePackage storePackage)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    dal.BeginTransaction();
                    if (storePackage.AllStores)
                    {
                        IEnumerable<Store> StoreList =  dal.List<Store>("STR_LST_STORE_SP").ToList();
                        foreach (Store st in StoreList)
                        {
                            storePackage.Store = st.StoreId;
                            dal.Create<StorePackage>(storePackage);
                        }
                    }
                    else
                    {
                        foreach (int storeId in storePackage.StoreList)
                        {
                            storePackage.Store = storeId;
                            dal.Create<StorePackage>(storePackage);
                        }
                    }
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }

            }
            
        }

        public IEnumerable<StorePackage> ListStorePackagesByStoreId(long packageId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmPackageId = dal.CreateParameter("Package", packageId);
                return dal.List<Overtech.DataModels.Price.StorePackage>("PRC_LST_STOREPACKAGE_SP", prmPackageId).ToList();
            }
        }
            
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}