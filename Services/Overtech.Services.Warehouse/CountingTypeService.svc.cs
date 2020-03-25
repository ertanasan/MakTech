// Created by OverGenerator
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
    public class CountingTypeService : CRUDLDataService<Overtech.DataModels.Warehouse.CountingType>, ICountingTypeService
    {
        /*Section="Constructor-1"*/
        public CountingTypeService()
        {
        }

        /*Section="Constructor-2"*/
        internal CountingTypeService(IDAL dal)
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