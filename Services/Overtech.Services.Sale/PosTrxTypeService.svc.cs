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
    public class PosTrxTypeService : CRUDLDataService<Overtech.DataModels.Sale.PosTrxType>, IPosTrxTypeService
    {
        /*Section="Constructor-1"*/
        public PosTrxTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal PosTrxTypeService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Sale.PosTrxType Find(string trxType)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmTrxType = dal.CreateParameter("TrxType", trxType);
                return dal.Read<Overtech.DataModels.Sale.PosTrxType>("SLS_SEL_FINDPOSTRXTYPE_SP", prmTrxType);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}