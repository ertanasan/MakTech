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
    public class OverStoreTaskStatusService : CRUDLDataService<Overtech.DataModels.OverStoreMain.OverStoreTaskStatus>, IOverStoreTaskStatusService
    {
        /*Section="Constructor-1"*/
        public OverStoreTaskStatusService()
        {
        }

        /*Section="Constructor-2"*/
        internal OverStoreTaskStatusService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.OverStoreMain.OverStoreTaskStatus Find(string status)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStatus = dal.CreateParameter("Status", status);
                return dal.Read<Overtech.DataModels.OverStoreMain.OverStoreTaskStatus>("OSM_SEL_FINDTASKSTATUS_SP", prmStatus);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}