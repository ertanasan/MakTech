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
    public class StorePropertyTypeService : CRUDLDataService<Overtech.DataModels.Store.StorePropertyType>, IStorePropertyTypeService
    {
        /*Section="Constructor-1"*/
        public StorePropertyTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal StorePropertyTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<StorePropertyType> ListRemaningPropertyTypes(long storeId)
        {

            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStoreId = dal.CreateParameter("Store", storeId);

               return  dal.List<StorePropertyType>("STR_LST_REMANINGPROPERTYTYPES_SP", prmStoreId).ToList();
            }

        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}