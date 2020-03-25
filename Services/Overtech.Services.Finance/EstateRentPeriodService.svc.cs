// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Core.Logger;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Finance;
using Overtech.ServiceContracts.Finance;

/*Section="ClassHeader"*/
namespace Overtech.Services.Finance
{
    [OTInspectorBehavior]
    public class EstateRentPeriodService : CRUDLDataService<Overtech.DataModels.Finance.EstateRentPeriod>, IEstateRentPeriodService
    {
        private ILogger _logger;

        /*Section="Constructor-1"*/
        public EstateRentPeriodService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(typeof(EstateRentPeriodService));
        }

        /*Section="Constructor-2"*/
        internal EstateRentPeriodService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-ListRentPaymentPlans"*/
        public IEnumerable<RentPaymentPlan> ListRentPaymentPlans(long estateRentPeriodId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmRentPeriod = dal.CreateParameter("RentPeriod", estateRentPeriodId);
                return dal.List<RentPaymentPlan>("FIN_LST_RENTPAYMENTPLAN_SP", prmRentPeriod).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public long GenerateAllPeriods(bool isKeepExistingRecords)
        {
            using (IDAL dal = this.DAL)
            {
                long generatedPeriodsCount;
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmKeepExistingRecords = dal.CreateParameter("KeepExistingRecords", isKeepExistingRecords);
                    generatedPeriodsCount = dal.ExecuteNonQuery("FIN_INS_GENERATEPERIODS_SP", prmKeepExistingRecords);
                }
                catch (Exception ex)
                {
                    _logger.Error($" ServiceName : EstateRentPeriodService, MethodName : GenerateAllPeriods, Input : ({isKeepExistingRecords.ToString()}), Exception : {ex.Message}");
                    dal.RollbackTransaction();
                    throw;
                }
                return generatedPeriodsCount;
            }
        }

        public long ClonePeriod(long templateRecordId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmTemplateRecordId = dal.CreateParameter("TemplateRecordId", templateRecordId);
                    IUniParameter prmClonedRecordId = dal.CreateParameter("ClonedRecordId", 8, System.Data.ParameterDirection.Output, 0);
                    dal.ExecuteNonQuery("FIN_INS_CLONEPERIOD_SP", prmTemplateRecordId, prmClonedRecordId);
                    dal.CommitTransaction();
                    return prmClonedRecordId.Value.To<long>();
                }
                catch (Exception ex)
                {
                    _logger.Error($" ServiceName : EstateRentPeriodService, MethodName : ClonePeriod, Input : ({templateRecordId.ToString()}), Exception : {ex.Message}");
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}