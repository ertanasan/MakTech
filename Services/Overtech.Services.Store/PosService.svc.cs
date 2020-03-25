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
    public class PosService : CRUDLDataService<Overtech.DataModels.Store.Pos>, IPosService
    {
        /*Section="Constructor-1"*/
        public PosService()
        {
        }

        /*Section="Constructor-2"*/
        internal PosService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.

        public IEnumerable<Pos> ListStorePos(long storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStore = dal.CreateParameter("Store", storeId);
                return dal.List<Pos>("STR_LST_POS_SP", prmStore).ToList();
            }
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}