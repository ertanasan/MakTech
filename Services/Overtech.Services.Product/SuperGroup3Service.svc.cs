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
    public class SuperGroup3Service : CRUDLDataService<Overtech.DataModels.Product.SuperGroup3>, ISuperGroup3Service
    {
        /*Section="Constructor-1"*/
        public SuperGroup3Service()
        {
        }

        /*Section="Constructor-2"*/
        internal SuperGroup3Service(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.SuperGroup3 Find(string superGroup3Name)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmSuperGroup3Name = dal.CreateParameter("SuperGroup3Name", superGroup3Name);
                return dal.Read<Overtech.DataModels.Product.SuperGroup3>("PRD_SEL_FINDSUPERGROUP3_SP", prmSuperGroup3Name);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}