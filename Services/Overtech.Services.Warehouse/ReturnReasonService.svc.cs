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
    public class ReturnReasonService : CRUDLDataService<Overtech.DataModels.Warehouse.ReturnReason>, IReturnReasonService
    {
        /*Section="Constructor-1"*/
        public ReturnReasonService()
        {
        }

        /*Section="Constructor-2"*/
        internal ReturnReasonService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Warehouse.ReturnReason Find(string reasonName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmReasonName = dal.CreateParameter("ReasonName", reasonName);
                return dal.Read<Overtech.DataModels.Warehouse.ReturnReason>("WHS_SEL_FINDRETURNREASON_SP", prmReasonName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}