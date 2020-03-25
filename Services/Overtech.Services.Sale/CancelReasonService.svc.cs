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
using Overtech.Core.Application;
using Overtech.Core.Logger;

/*Section="ClassHeader"*/
namespace Overtech.Services.Sale
{
    [OTInspectorBehavior]
    public class CancelReasonService : CRUDLDataService<Overtech.DataModels.Sale.CancelReason>, ICancelReasonService
    {
        private ILogger _logger;

        /*Section="Constructor-1"*/
        public CancelReasonService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.GetLogger(typeof(CancelReasonService));
        }

        /*Section="Constructor-2"*/
        internal CancelReasonService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<CancelReason> ListRecCancelsByDate (DateTime recDate, int storeId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmReconciliationDate = dal.CreateParameter("ReconciliationDate", recDate);
                IUniParameter prmStoreId = dal.CreateParameter("StoreId", storeId);
                return dal.List<CancelReason>("SLS_LST_CANCELREASONBYDATE_SP", prmReconciliationDate, prmStoreId).ToList();
            }
        }

        public void SaveCancelReasons(IEnumerable<CancelReason> rec)
        {
            using (IDAL dal = this.DAL)
            {
                try
                {
                    dal.BeginTransaction();
                    foreach (CancelReason cr in rec)
                    {
                        if (cr.CancelReasonId > 0)
                        {
                            dal.Update<CancelReason>(cr);
                        } else
                        {
                            cr.Event = 1;
                            cr.Organization = OTApplication.Context.Organization.Id;
                            cr.CancelReasonId = dal.Create<CancelReason>(cr);
                        }
                    }
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    _logger.Error($" ServiceName : CancelReasonService, MethodName : SaveCancelReasons, Input : {Newtonsoft.Json.JsonConvert.SerializeObject(rec)}, Exception : {ex.ToString()}");
                    throw ex;
                }
            }
        }

        public override IEnumerable<CancelReason> List()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<CancelReason>("SLS_LST_CANCELREASONTODAY_SP").ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}