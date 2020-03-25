// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ServiceModel;

using Overtech.Core.Contract;
using Overtech.DataModels.Announcement;

/*Section="ClassHeader"*/
namespace Overtech.ServiceContracts.Announcement
{
    [ServiceContract]
    public interface ISuggestionService : ICRUDLServiceContract<Overtech.DataModels.Announcement.Suggestion>
    {

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [OperationContract]
        IEnumerable<Suggestion> ListAdmin(bool suggestionAdmin);

        [OperationContract]
        void UpdateStatus(long suggestionId, long statusId);

        [OperationContract]
        void TakeAction(DataModels.Announcement.Suggestion dataObject, long actionId, string choice, string comment);

        [OperationContract]
        IEnumerable<SuggestionHistory> ListHistoryData(long suggestionId);
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

