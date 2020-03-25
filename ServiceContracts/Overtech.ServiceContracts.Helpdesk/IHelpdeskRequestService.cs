// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.BPMAction;
using Overtech.DataModels.Helpdesk;
using Overtech.Shared.BPM;
using Overtech.Shared.OverStore.BPM;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Helpdesk
{
    [ServiceContract]
    public interface IHelpdeskRequestService : ICRUDLServiceContract<Overtech.DataModels.Helpdesk.HelpdeskRequest>
    {

        /*Section="Method-ListRequestDetails"*/
        [OperationContract]
        IEnumerable<RequestDetail> ListRequestDetails(long helpdeskRequestId);


        /*Section="Method-ListRequestAdditionalInfoes"*/
        [OperationContract]
        IEnumerable<RequestAdditionalInfo> ListRequestAdditionalInfoes(long helpdeskRequestId);

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OperationContract]
        HelpdeskRequest CreateRequest(Overtech.DataModels.Helpdesk.HelpdeskRequest rec);

        [OperationContract]
        HelpdeskRequest ReadRequest(long id);

        [OperationContract]
        void UpdateStatus(long requestId, int statusId);

        [OperationContract]
        void TakeAction(DataModels.Helpdesk.HelpdeskRequest dataObject, long actionId, string choice, string comment);

        [OperationContract]
        IEnumerable<HelpdeskRequest> ListFiltered(Boolean OpenFlag, DateTime StartDate, DateTime EndDate);

        [OperationContract]
        RequestBPM UserTask(long ProcessInstanceId);

        [OperationContract]
        DataSet TaskDashboard();

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

