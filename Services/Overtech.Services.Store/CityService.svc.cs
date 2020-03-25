// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Store;
using Overtech.ServiceContracts.Store;

/*Section="ClassHeader"*/
namespace Overtech.Services.Store
{
    [OTInspectorBehavior]
    public class CityService : CRUDLDataService<Overtech.DataModels.Store.City>, ICityService
    {
        /*Section="Constructor-1"*/
        public CityService()
        {
        }

        /*Section="Constructor-2"*/
        internal CityService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Store.City Find(string cityName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmCityName = dal.CreateParameter("CityName", cityName);
                return dal.Read<Overtech.DataModels.Store.City>("STR_SEL_FINDCITY_SP", prmCityName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}