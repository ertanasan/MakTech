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
    public class SeasonTypeService : CRUDLDataService<Overtech.DataModels.Product.SeasonType>, ISeasonTypeService
    {
        /*Section="Constructor-1"*/
        public SeasonTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal SeasonTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.SeasonType Find(string seasonTypeName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmSeasonTypeName = dal.CreateParameter("SeasonTypeName", seasonTypeName);
                return dal.Read<Overtech.DataModels.Product.SeasonType>("PRD_SEL_FINDSEASONTYPE_SP", prmSeasonTypeName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}