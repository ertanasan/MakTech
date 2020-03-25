// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Price;
using Overtech.ServiceContracts.Price;

/*Section="ClassHeader"*/
namespace Overtech.Services.Price
{
    [OTInspectorBehavior]
    public class PackageTypeService : CRUDLDataService<Overtech.DataModels.Price.PackageType>, IPackageTypeService
    {
        /*Section="Constructor-1"*/
        public PackageTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal PackageTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Price.PackageType Find(string packageTypeName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmPackageTypeName = dal.CreateParameter("PackageTypeName", packageTypeName);
                return dal.Read<Overtech.DataModels.Price.PackageType>("PRC_SEL_FINDPACKAGETYPE_SP", prmPackageTypeName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}