﻿// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Warehouse;
using Overtech.ServiceContracts.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class GatheringPalletStatusService : CRUDLDataService<Overtech.DataModels.Warehouse.GatheringPalletStatus>, IGatheringPalletStatusService
    {
        /*Section="Constructor-1"*/
        public GatheringPalletStatusService()
        {
        }

        /*Section="Constructor-2"*/
        internal GatheringPalletStatusService(IDAL dal)
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