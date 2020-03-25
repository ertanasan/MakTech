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
    public class FixtureBrandService : CRUDLDataService<Overtech.DataModels.Product.FixtureBrand>, IFixtureBrandService
    {
        /*Section="Constructor-1"*/
        public FixtureBrandService()
        {
        }

        /*Section="Constructor-2"*/
        internal FixtureBrandService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-ListFixtureModels"*/
        public IEnumerable<FixtureModel> ListFixtureModels(long fixtureBrandId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmBrand = dal.CreateParameter("Brand", fixtureBrandId);
                return dal.List<FixtureModel>("PRD_LST_FIXTUREMODEL_SP", prmBrand).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}