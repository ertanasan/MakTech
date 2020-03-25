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
    public class OverstoreSharedService : CRUDLDataService<Overtech.DataModels.Store.BPMHistory>, IOverstoreSharedService
    {
        /*Section="Constructor-1"*/
        public OverstoreSharedService()
        {
        }

        /*Section="Constructor-2"*/
        internal OverstoreSharedService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public IEnumerable<BPMHistory> ListBPMHistoryData(long processInstanceId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmProcessInstance = dal.CreateParameter("ProcessInstance", processInstanceId);
                return dal.List<BPMHistory>("BPM_LST_HISTORYDATA_SP", prmProcessInstance).ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}