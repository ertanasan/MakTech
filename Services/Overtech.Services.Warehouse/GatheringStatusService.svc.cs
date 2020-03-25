// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Warehouse;
using Overtech.ServiceContracts.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class GatheringStatusService : CRUDLDataService<Overtech.DataModels.Warehouse.GatheringStatus>, IGatheringStatusService
    {
        /*Section="Constructor-1"*/
        public GatheringStatusService()
        {
        }

        /*Section="Constructor-2"*/
        internal GatheringStatusService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Warehouse.GatheringStatus Find(string statusName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmStatusName = dal.CreateParameter("StatusName", statusName);
                return dal.Read<Overtech.DataModels.Warehouse.GatheringStatus>("WHS_SEL_FINDGATHERINGSTATUS_SP", prmStatusName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}