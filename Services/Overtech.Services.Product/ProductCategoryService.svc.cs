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
    public class ProductCategoryService : CRUDLDataService<Overtech.DataModels.Product.ProductCategory>, IProductCategoryService
    {
        /*Section="Constructor-1"*/
        public ProductCategoryService()
        {
        }

        /*Section="Constructor-2"*/
        internal ProductCategoryService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.ProductCategory Find(string category)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmCategory = dal.CreateParameter("Category", category);
                return dal.Read<Overtech.DataModels.Product.ProductCategory>("PRD_SEL_FINDCATEGORY_SP", prmCategory);
            }
        }

        /*Section="Method-ListSubgroups"*/
        public IEnumerable<Subgroup> ListSubgroups(long categoryID)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmCategory = dal.CreateParameter("Category", categoryID);
                return dal.List<Subgroup>("PRD_LST_SUBGROUP_SP", prmCategory).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}