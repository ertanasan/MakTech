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
using System;
using Overtech.ServiceContracts.Price;
using Overtech.ViewModels.Price;
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Price
{
    [RoutePrefix("api/Price/PriceLabel")]

    public class PriceLabelController : CRUDLApiController<Overtech.DataModels.Price.LabelPrice, IPriceLabelService, Overtech.ViewModels.Price.LabelPrice>
    {
        /*Section="Constructor"*/
        public PriceLabelController(
            ILoggerFactory loggerFactory,
            IPriceLabelService priceLabelService)
            : base(loggerFactory, priceLabelService)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized


        //[HttpGet]
        //[Route("PriceVersionsList")]
        //[OTControllerAction("List")]
        //public IEnumerable<PriceVersion> ReconciliationList()
        //{
        //    return _dataService.ListPriceVersions().Map<DataModels.Price.PriceVersion, PriceVersion>();
        //}

        [HttpGet]
        [Route("PriceLabelList")]
        [OTControllerAction("List")]
        public IEnumerable<LabelPrice> PriceLabelList(/*long packageVersionID*/)
        {
            return _dataService.ListPriceLabel(/*packageVersionID*/).Map<DataModels.Price.LabelPrice, LabelPrice>();
        }

        [HttpGet]
        [Route("PriceLabelCheckedList")]
        [OTControllerAction("List")]
        public IEnumerable<int> PriceLabelCheckedList(string pS)
        {
            return _dataService.ListPriceLabelChecked(pS).ToList();

        }

        #endregion Customized
        /*Section="ClassFooter"*/
    }
}