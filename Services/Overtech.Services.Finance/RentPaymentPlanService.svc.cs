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
    public class RentPaymentPlanService : CRUDLDataService<Overtech.DataModels.Finance.RentPaymentPlan>, IRentPaymentPlanService
    {
        private ILogger _logger;

        /*Section="Constructor-1"*/
        public RentPaymentPlanService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(typeof(RentPaymentPlanService));
        }

        /*Section="Constructor-2"*/
        internal RentPaymentPlanService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public long GenerateAllPayments(bool isKeepExistingRecords)
        {
            using (IDAL dal = this.DAL)
            {
                long generatedPaymentsCount;
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmKeepExistingRecords = dal.CreateParameter("KeepExistingRecords", isKeepExistingRecords);
                    generatedPaymentsCount = dal.ExecuteNonQuery("FIN_INS_GENERATEPAYMENTS_SP", prmKeepExistingRecords);
                }
                catch (Exception ex)
                {
                    _logger.Error($" ServiceName : RentPaymentPlanService, MethodName : GenerateAllPayments, Input : ({isKeepExistingRecords.ToString()}), Exception : {ex.Message}");
                    dal.RollbackTransaction();                    
                    throw;
                }
                return generatedPaymentsCount;
            }
        }

        public long ClonePayment(long templateRecordId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmTemplateRecordId = dal.CreateParameter("TemplateRecordId", templateRecordId);
                    IUniParameter prmClonedRecordId = dal.CreateParameter("ClonedRecordId", 8, System.Data.ParameterDirection.Output, 0);
                    dal.ExecuteNonQuery("FIN_INS_CLONEPAYMENT_SP", prmTemplateRecordId, prmClonedRecordId);
                    dal.CommitTransaction();
                    return prmClonedRecordId.Value.To<long>();
                }
                catch (Exception ex)
                {
                    _logger.Error($" ServiceName : RentPaymentPlanService, MethodName : ClonePayment, Input : ({templateRecordId.ToString()}), Exception : {ex.Message}");
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}