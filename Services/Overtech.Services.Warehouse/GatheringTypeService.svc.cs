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
    public class GatheringTypeService : CRUDLDataService<Overtech.DataModels.Warehouse.GatheringType>, IGatheringTypeService
    {
        /*Section="Constructor-1"*/
        public GatheringTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal GatheringTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Warehouse.GatheringType Find(string gatheringTypeName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmGatheringTypeName = dal.CreateParameter("GatheringTypeName", gatheringTypeName);
                return dal.Read<Overtech.DataModels.Warehouse.GatheringType>("WHS_SEL_FINDGATHERINGTYPE_SP", prmGatheringTypeName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}