// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.StoreUpload;
using Overtech.ServiceContracts.StoreUpload;

/*Section="ClassHeader"*/
namespace Overtech.Services.StoreUpload
{
    [OTInspectorBehavior]
    public class StatusService : CRUDLDataService<Overtech.DataModels.StoreUpload.Status>, IStatusService
    {
        /*Section="Constructor-1"*/
        public StatusService()
        {
        }

        /*Section="Constructor-2"*/
        internal StatusService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.StoreUpload.Status Find(string name)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmName = dal.CreateParameter("Name", name);
                return dal.Read<Overtech.DataModels.StoreUpload.Status>("SUP_SEL_FINDSTATUS_SP", prmName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}