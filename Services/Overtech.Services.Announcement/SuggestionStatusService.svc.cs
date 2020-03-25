// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Announcement;
using Overtech.ServiceContracts.Announcement;

/*Section="ClassHeader"*/
namespace Overtech.Services.Announcement
{
    [OTInspectorBehavior]
    public class SuggestionStatusService : CRUDLDataService<Overtech.DataModels.Announcement.SuggestionStatus>, ISuggestionStatusService
    {
        /*Section="Constructor-1"*/
        public SuggestionStatusService()
        {
        }

        /*Section="Constructor-2"*/
        internal SuggestionStatusService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}