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
    public class UnitService : CRUDLDataService<Overtech.DataModels.Product.Unit>, IUnitService
    {
        /*Section="Constructor-1"*/
        public UnitService()
        {
        }

        /*Section="Constructor-2"*/
        internal UnitService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.Unit Find(string name)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmName = dal.CreateParameter("Name", name);
                return dal.Read<Overtech.DataModels.Product.Unit>("PRD_SEL_FINDUNIT_SP", prmName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}