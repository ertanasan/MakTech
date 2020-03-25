// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.OverStoreMain;
using Overtech.ServiceContracts.OverStoreMain;

/*Section="ClassHeader"*/
namespace Overtech.Services.OverStoreMain
{
    [OTInspectorBehavior]
    public class OverStoreTaskHistoryService : CRUDLDataService<Overtech.DataModels.OverStoreMain.OverStoreTaskHistory>, IOverStoreTaskHistoryService
    {
        /*Section="Constructor-1"*/
        public OverStoreTaskHistoryService()
        {
        }

        /*Section="Constructor-2"*/
        internal OverStoreTaskHistoryService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Search"*/
        public IEnumerable<Overtech.DataModels.OverStoreMain.OverStoreTaskHistory> Search(long? overStoreTask)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmOverStoreTask = dal.CreateParameter("OverStoreTask", overStoreTask);
                return dal.List<Overtech.DataModels.OverStoreMain.OverStoreTaskHistory>("OSM_LST_SEARCHTASKHISTORY_SP", prmOverStoreTask).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}