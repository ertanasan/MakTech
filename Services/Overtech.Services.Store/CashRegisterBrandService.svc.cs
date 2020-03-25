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
    public class CashRegisterBrandService : CRUDLDataService<Overtech.DataModels.Store.CashRegisterBrand>, ICashRegisterBrandService
    {
        /*Section="Constructor-1"*/
        public CashRegisterBrandService()
        {
        }

        /*Section="Constructor-2"*/
        internal CashRegisterBrandService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Store.CashRegisterBrand Find(string name)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmName = dal.CreateParameter("Name", name);
                return dal.Read<Overtech.DataModels.Store.CashRegisterBrand>("STR_SEL_FINDCASHREGISTERBRAND_SP", prmName);
            }
        }

        /*Section="Method-ListCashRegisterModels"*/
        public IEnumerable<CashRegisterModel> ListCashRegisterModels(long cashRegisterBrandId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmBrand = dal.CreateParameter("Brand", cashRegisterBrandId);
                return dal.List<CashRegisterModel>("STR_LST_CASHREGISTERMODEL_SP", prmBrand).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}