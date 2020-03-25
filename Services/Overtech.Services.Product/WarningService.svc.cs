// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Product;
using Overtech.ServiceContracts.Product;

/*Section="ClassHeader"*/
namespace Overtech.Services.Product
{
    [OTInspectorBehavior]
    public class WarningService : CRUDLDataService<Overtech.DataModels.Product.Warning>, IWarningService
    {
        /*Section="Constructor-1"*/
        public WarningService()
        {
        }

        /*Section="Constructor-2"*/
        internal WarningService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.Warning Find(string warningText)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmWarningText = dal.CreateParameter("WarningText", warningText);
                return dal.Read<Overtech.DataModels.Product.Warning>("PRD_SEL_FINDWARNING_SP", prmWarningText);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}