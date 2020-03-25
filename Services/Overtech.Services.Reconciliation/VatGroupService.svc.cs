// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Reconciliation;
using Overtech.ServiceContracts.Reconciliation;

/*Section="ClassHeader"*/
namespace Overtech.Services.Reconciliation
{
    [OTInspectorBehavior]
    public class VatGroupService : CRUDLDataService<Overtech.DataModels.Reconciliation.VatGroup>, IVatGroupService
    {
        /*Section="Constructor-1"*/
        public VatGroupService()
        {
        }

        /*Section="Constructor-2"*/
        internal VatGroupService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Reconciliation.VatGroup Find(string vatRate)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmVatRate = dal.CreateParameter("VatRate", vatRate);
                return dal.Read<Overtech.DataModels.Reconciliation.VatGroup>("RCL_SEL_FINDVATGROUP_SP", prmVatRate);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}