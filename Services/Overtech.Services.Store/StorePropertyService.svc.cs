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
    public class StorePropertyService : CRUDLDataService<Overtech.DataModels.Store.StoreProperty>, IStorePropertyService
    {
        /*Section="Constructor-1"*/
        public StorePropertyService()
        {
        }

        /*Section="Constructor-2"*/
        internal StorePropertyService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public IEnumerable<StoreProperty> ListStoreProperties(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStore = dal.CreateParameter("Store", storeId);
                return dal.List<StoreProperty>("STR_LST_PROPERTY_SP", prmStore).ToList();
            }
        }

        //public int CreateStorePropertyForAllStores(long propertyTypeId, string value)
        //{
        //    using (IDAL dal = this.DAL)
        //    {
        //        IUniParameter prmPropertyType = dal.CreateParameter("PropertyType", propertyTypeId);
        //        IUniParameter prmValue = dal.CreateParameter("PropertyValue", value);

        //        IUniParameter[] spParams = new IUniParameter[2];
        //        spParams[0] = prmPropertyType;
        //        spParams[1] = prmValue;

        //        return dal.ExecuteNonQuery("STR_INS_PROPERTYTOALLSTORES_SP", spParams);
        //    }
        //}

        //public int UpdateStorePropertiyForAllStores(long propertyTypeId, string value)
        //{
        //    using (IDAL dal = this.DAL)
        //    {
        //        IUniParameter prmPropertyType = dal.CreateParameter("PropertyType", propertyTypeId);
        //        IUniParameter prmValue = dal.CreateParameter("PropertyValue", value);

        //        IUniParameter[] spParams = new IUniParameter[2];
        //        spParams[0] = prmPropertyType;
        //        spParams[1] = prmValue;

        //        return dal.ExecuteNonQuery("STR_UPD_PROPERTYFORALLSTORES_SP", spParams);
        //    }
        //}

        public int CreateStorePropertyForAllStores(long propertyTypeId, string value)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmPropertyType = dal.CreateParameter("PropertyType", propertyTypeId);
                    IUniParameter prmValue = dal.CreateParameter("PropertyValue", value);
                    int rowCount = dal.ExecuteNonQuery("STR_INS_PROPERTYTOALLSTORES_SP", prmPropertyType, prmValue);
                    dal.CommitTransaction();
                    return rowCount;
                }
                catch
                {
                    dal.RollbackTransaction();
                    return -1;
                }
            }
        }

        public int UpdateStorePropertiyForAllStores(long propertyTypeId, string value)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmPropertyType = dal.CreateParameter("PropertyType", propertyTypeId);
                    IUniParameter prmValue = dal.CreateParameter("PropertyValue", value);

                    IUniParameter[] spParams = new IUniParameter[2];
                    spParams[0] = prmPropertyType;
                    spParams[1] = prmValue;

                    int rowCount = dal.ExecuteNonQuery("STR_UPD_PROPERTYFORALLSTORES_SP", spParams);
                    dal.CommitTransaction();

                    return rowCount;
                }
                catch
                {
                    dal.RollbackTransaction();
                    return -1;
                }
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}