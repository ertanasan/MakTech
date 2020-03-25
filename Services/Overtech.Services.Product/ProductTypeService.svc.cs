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
    public class ProductTypeService : CRUDLDataService<Overtech.DataModels.Product.ProductType>, IProductTypeService
    {
        /*Section="Constructor-1"*/
        public ProductTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal ProductTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.ProductType Find(string subgroup)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmSubgroup = dal.CreateParameter("Subgroup", subgroup);
                return dal.Read<Overtech.DataModels.Product.ProductType>("PRD_SEL_FINDSUBGROUP_SP", prmSubgroup);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}