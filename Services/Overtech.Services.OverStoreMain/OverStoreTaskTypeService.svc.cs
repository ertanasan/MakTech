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
    public class OverStoreTaskTypeService : CRUDLDataService<Overtech.DataModels.OverStoreMain.OverStoreTaskType>, IOverStoreTaskTypeService
    {
        /*Section="Constructor-1"*/
        public OverStoreTaskTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal OverStoreTaskTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.OverStoreMain.OverStoreTaskType Find(string taskType)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmTaskType = dal.CreateParameter("TaskType", taskType);
                return dal.Read<Overtech.DataModels.OverStoreMain.OverStoreTaskType>("OSM_SEL_FINDTASKTYPE_SP", prmTaskType);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}