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
    public class SuperGroup2Service : CRUDLDataService<Overtech.DataModels.Product.SuperGroup2>, ISuperGroup2Service
    {
        /*Section="Constructor-1"*/
        public SuperGroup2Service()
        {
        }

        /*Section="Constructor-2"*/
        internal SuperGroup2Service(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.SuperGroup2 Find(string superGroup2Name)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmSuperGroup2Name = dal.CreateParameter("SuperGroup2Name", superGroup2Name);
                return dal.Read<Overtech.DataModels.Product.SuperGroup2>("PRD_SEL_FINDSUPERGROUP2_SP", prmSuperGroup2Name);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}