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
    public class StoreFixtureService : CRUDLDataService<Overtech.DataModels.Store.StoreFixture>, IStoreFixtureService
    {
        /*Section="Constructor-1"*/
        public StoreFixtureService()
        {
        }

        /*Section="Constructor-2"*/
        internal StoreFixtureService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<StoreFixture> GetUserFixture()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<StoreFixture>("STR_LST_USERFIXTURE_SP").ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}