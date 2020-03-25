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
    public class SuggestionTypeService : CRUDLDataService<Overtech.DataModels.Announcement.SuggestionType>, ISuggestionTypeService
    {
        /*Section="Constructor-1"*/
        public SuggestionTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal SuggestionTypeService(IDAL dal)
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