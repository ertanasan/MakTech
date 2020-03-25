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
    public class StorageConditionService : CRUDLDataService<Overtech.DataModels.Product.StorageCondition>, IStorageConditionService
    {
        /*Section="Constructor-1"*/
        public StorageConditionService()
        {
        }

        /*Section="Constructor-2"*/
        internal StorageConditionService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Product.StorageCondition Find(string condition)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmCondition = dal.CreateParameter("Condition", condition);
                return dal.Read<Overtech.DataModels.Product.StorageCondition>("PRD_SEL_FINDSTORAGECONDITION_SP", prmCondition);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}