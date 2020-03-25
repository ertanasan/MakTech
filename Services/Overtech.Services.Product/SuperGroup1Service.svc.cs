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
    public class SuperGroup1Service : CRUDLDataService<SuperGroup1>, ISuperGroup1Service
    {
        /*Section="Constructor-1"*/
        public SuperGroup1Service()
        {
        }

        /*Section="Constructor-2"*/
        internal SuperGroup1Service(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.SuperGroup1 Find(string superGroup1Name)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmSuperGroup1Name = dal.CreateParameter("SuperGroup1Name", superGroup1Name);
                return dal.Read<Overtech.DataModels.Product.SuperGroup1>("PRD_SEL_FINDSUPERGROUP1_SP", prmSuperGroup1Name);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}