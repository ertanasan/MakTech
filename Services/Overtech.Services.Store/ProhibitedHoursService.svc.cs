﻿// Created by OverGenerator
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
    public class ProhibitedHoursService : CRUDLDataService<Overtech.DataModels.Store.ProhibitedHours>, IProhibitedHoursService
    {
        /*Section="Constructor-1"*/
        public ProhibitedHoursService()
        {
        }

        /*Section="Constructor-2"*/
        internal ProhibitedHoursService(IDAL dal)
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