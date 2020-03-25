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
    public class SubgroupService : CRUDLDataService<Overtech.DataModels.Product.Subgroup>, ISubgroupService
    {
        /*Section="Constructor-1"*/
        public SubgroupService()
        {
        }

        /*Section="Constructor-2"*/
        internal SubgroupService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.Subgroup Find(string subgroupName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmSubgroupName = dal.CreateParameter("SubgroupName", subgroupName);
                return dal.Read<Overtech.DataModels.Product.Subgroup>("PRD_SEL_FINDSUBGROUP_SP", prmSubgroupName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}