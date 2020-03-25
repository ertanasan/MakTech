// Created by OverGenerator
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
    [RoutePrefix("api/Warehouse/Supplier")]
    public class SupplierController : CRUDLApiController<Overtech.DataModels.Warehouse.Supplier, ISupplierService, Overtech.ViewModels.Warehouse.Supplier>
    {
        /*Section="Constructor"*/
        public SupplierController(
            ILoggerFactory loggerFactory,
            ISupplierService supplierService)
            : base(loggerFactory, supplierService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}