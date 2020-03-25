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
    public class GatheringDetailService : CRUDLDataService<Overtech.DataModels.Warehouse.GatheringDetail>, IGatheringDetailService
    {
        /*Section="Constructor-1"*/
        public GatheringDetailService()
        {
        }

        /*Section="Constructor-2"*/
        internal GatheringDetailService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public IEnumerable<Overtech.DataModels.Warehouse.GatheringDetail> ListGatheringDetail(long gatheringId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmGatheringId = dal.CreateParameter("GatheringId", gatheringId);
                return dal.List<GatheringDetail>("WHS_LST_GATHERINGDETAIL_SP", prmGatheringId).ToList();
            }
        }

        public IEnumerable<Overtech.DataModels.Product.Product> ListGatheringControlAddProduct(long GatheringId, int PalletNo)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmGatheringId = dal.CreateParameter("GatheringId", GatheringId);
                IUniParameter prmPalletNo = dal.CreateParameter("PalletNo", PalletNo);
                return dal.List<Overtech.DataModels.Product.Product>("WHS_LST_GATHERINGCONTROLADDPRODUCT_SP", prmGatheringId, prmPalletNo).ToList();
            }
        }

        public void AddProducttoControlList(long GatheringId, int PalletNo, int ProductId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmGatheringId = dal.CreateParameter("GatheringId", GatheringId);
                    IUniParameter prmPalletNo = dal.CreateParameter("PalletNo", PalletNo);
                    IUniParameter prmProductId = dal.CreateParameter("ProductId", ProductId);
                    dal.ExecuteNonQuery("WHS_INS_ADDPRODUCTTOCONTROL_SP", prmGatheringId, prmPalletNo, prmProductId);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }

        public void LogControlZero(long GatheringPalletId, long GatheringDetailId, decimal? PreviousQuantity)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmGatheringPalletId = dal.CreateParameter("GatheringPalletId", GatheringPalletId);
                    IUniParameter prmGatheringDetailId = dal.CreateParameter("GatheringDetailId", GatheringDetailId);
                    IUniParameter prmPreviousQuantity = dal.CreateParameter("PreviousQuantity", PreviousQuantity);
                    dal.ExecuteNonQuery("WHS_INS_LOGCONTROLZERO_SP", prmGatheringPalletId, prmGatheringDetailId, prmPreviousQuantity);
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw ex;
                }
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}