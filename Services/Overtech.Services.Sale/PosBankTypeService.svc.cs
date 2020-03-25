// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Sale;
using Overtech.ServiceContracts.Sale;

/*Section="ClassHeader"*/
namespace Overtech.Services.Sale
{
    [OTInspectorBehavior]
    public class PosBankTypeService : CRUDLDataService<Overtech.DataModels.Sale.PosBankType>, IPosBankTypeService
    {
        /*Section="Constructor-1"*/
        public PosBankTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal PosBankTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Sale.PosBankType Find(string bankType)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmBankType = dal.CreateParameter("BankType", bankType);
                return dal.Read<Overtech.DataModels.Sale.PosBankType>("SLS_SEL_FINDPOSBANKTYPE_SP", prmBankType);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}