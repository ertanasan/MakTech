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
    public class FixtureService : CRUDLDataService<Overtech.DataModels.Product.Fixture>, IFixtureService
    {
        /*Section="Constructor-1"*/
        public FixtureService()
        {
        }

        /*Section="Constructor-2"*/
        internal FixtureService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-ListFixtureBrands"*/
        public IEnumerable<FixtureBrand> ListFixtureBrands(long fixtureId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmFixture = dal.CreateParameter("Fixture", fixtureId);
                return dal.List<FixtureBrand>("PRD_LST_FIXTUREBRAND_SP", prmFixture).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}