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
using Overtech.Core.Logger;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class GatheringPalletService : CRUDLDataService<Overtech.DataModels.Warehouse.GatheringPallet>, IGatheringPalletService
    {
        private ILogger _logger;

        /*Section="Constructor-1"*/
        public GatheringPalletService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(typeof(GatheringPalletService));
        }

        /*Section="Constructor-2"*/
        internal GatheringPalletService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<GatheringPallet> ActiveControlPallets()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<GatheringPallet>("WHS_LST_ACTIVECONTROLPALLET_SP").ToList();
            }
            
        }

        public int StartControl(long gatheringPalletId, Boolean allowReControl)
        {
            using (IDAL dal = this.DAL)
            {
                int errorCode = 0;
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmGatheringPalletId = dal.CreateParameter("GatheringPalletId", gatheringPalletId);
                    IUniParameter prmAllowReControl = dal.CreateParameter("AllowReControl", allowReControl ? "Y" : "N");
                    IUniParameter prmErrorCode = dal.CreateParameter("ErrorCode", 4, System.Data.ParameterDirection.Output, 0);


                    dal.ExecuteNonQuery("WHS_UPD_STARTCONTROL_SP", prmGatheringPalletId, prmAllowReControl, prmErrorCode);
                    dal.CommitTransaction();
                    errorCode = prmErrorCode.Value.To<int>();
                    return errorCode;
                } catch (Exception ex)
                {
                    _logger.Error($" ServiceName : GatheringPalletService, MethodName : StartControl, Input : gatheringPalletId: {gatheringPalletId}, allowReControl: {allowReControl}, Exception : {ex.Message}");
                    dal.RollbackTransaction();
                    return 99;
                }
            }
        }

        public GatheringPallet GetPalletByGatheringId(long gatheringId, int palletNo)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmGatheringId = dal.CreateParameter("GatheringId", gatheringId);
                IUniParameter prmPalletNo = dal.CreateParameter("PalletNo", palletNo);
                return dal.Read<GatheringPallet>("WHS_SEL_PALLETBYGATHERINGID_SP", prmGatheringId, prmPalletNo);
            }
        }

        public IEnumerable<GatheringPallet> ListPalletByGatheringId(long gatheringId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmGatheringId = dal.CreateParameter("GatheringId", gatheringId);
                return dal.List<GatheringPallet>("WHS_LST_PALLETBYGATHERINGID_SP", prmGatheringId).ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}