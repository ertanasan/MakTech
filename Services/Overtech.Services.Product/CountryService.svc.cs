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
    public class CountryService : CRUDLCachedDataService<Overtech.DataModels.Product.Country>, ICountryService
    {
        /*Section="Constructor-1"*/
        public CountryService()
        {
        }

        /*Section="Constructor-2"*/
        internal CountryService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.Country Find(string countryName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmCountryName = dal.CreateParameter("CountryName", countryName);
                return dal.Read<Overtech.DataModels.Product.Country>("PRD_SEL_FINDCOUNTRY_SP", prmCountryName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}