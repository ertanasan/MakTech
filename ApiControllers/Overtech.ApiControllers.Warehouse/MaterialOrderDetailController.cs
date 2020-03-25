﻿// Created by OverGenerator
/*Section="Usings"*/
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using Overtech.Core.DataSource;
using Overtech.UI.DataSource;

using Overtech.Core.Data;
using Overtech.Core.Logger;
using Overtech.Service.Authorization;
using Overtech.UI.Web;
using Overtech.ServiceContracts.Warehouse;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Warehouse
{
    [RoutePrefix("api/Warehouse/MaterialOrderDetail")]
    public class MaterialOrderDetailController : CRUDLApiController<Overtech.DataModels.Warehouse.MaterialOrderDetail, IMaterialOrderDetailService, Overtech.ViewModels.Warehouse.MaterialOrderDetail>
    {
        /*Section="Constructor"*/
        public MaterialOrderDetailController(
            ILoggerFactory loggerFactory,
            IMaterialOrderDetailService materialOrderDetailService)
            : base(loggerFactory, materialOrderDetailService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}