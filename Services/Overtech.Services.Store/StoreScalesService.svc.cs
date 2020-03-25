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
    public class StoreScalesService : CRUDLDataService<Overtech.DataModels.Store.StoreScales>, IStoreScalesService
    {
        /*Section="Constructor-1"*/
        public StoreScalesService()
        {
        }

        /*Section="Constructor-2"*/
        internal StoreScalesService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<StoreScales> StoreScales(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmPackage = dal.CreateParameter("Store", storeId);
                return dal.List<StoreScales>("STR_LST_SCALE_SP", prmPackage).ToList();
            }
        }

        public IEnumerable<StoreScales> GetUserScale()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<StoreScales>("STR_LST_USERSCALE_SP").ToList();
            }
        }

        public override StoreScales Create(StoreScales dataObject)
        {
            return base.Create(dataObject);
        }

        public override void Update(StoreScales dataObject)
        {
            base.Update(dataObject);
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}