// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Warehouse;
using Overtech.ServiceContracts.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class TransferProductStatusService : CRUDLDataService<Overtech.DataModels.Warehouse.TransferProductStatus>, ITransferProductStatusService
    {
        /*Section="Constructor-1"*/
        public TransferProductStatusService()
        {
        }

        /*Section="Constructor-2"*/
        internal TransferProductStatusService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Warehouse.TransferProductStatus Find(string productStatusName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmProductStatusName = dal.CreateParameter("ProductStatusName", productStatusName);
                return dal.Read<Overtech.DataModels.Warehouse.TransferProductStatus>("WHS_SEL_FINDTRANSFERPRODUCTSTATUS_SP", prmProductStatusName);
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}