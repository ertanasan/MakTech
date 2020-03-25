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
using Overtech.ServiceContracts.Price;
using Overtech.ServiceContracts.Document;
using Overtech.ViewModels.Price;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Overtech.Core;
using System;
using System.Reflection;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Price
{
    [RoutePrefix("api/Price/PricePackage")]
    public class PricePackageController : CRUDLApiController<Overtech.DataModels.Price.PricePackage, IPricePackageService, Overtech.ViewModels.Price.PricePackage>
    {
        private IDocumentService _documentService;
        
        /*Section="Constructor"*/
        public PricePackageController(
            ILoggerFactory loggerFactory,
            IPricePackageService pricePackageService,
            IDocumentService documentService)
            : base(loggerFactory, pricePackageService)
        {
            _documentService = documentService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [HttpGet]
        [Route("PackagePerformance")]
        [OTControllerAction("GetReport")]
        public virtual Overtech.ViewModels.Price.PackagePerformance GetPackagePerformance(long packageId)
        {

            return _dataService.GetPackagePerformance(packageId).Map<Overtech.DataModels.Price.PackagePerformance, Overtech.ViewModels.Price.PackagePerformance>();

        }

        public override PricePackage Create([FromBody] PricePackage viewModel)
        {
            try
            {
                if(viewModel.ImageDocument.tempDocumentId > 0)
                {
                    viewModel.Image = viewModel.ImageDocument.tempDocumentId;
                }

                return base.Create(viewModel);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public override void Update(PricePackage viewModel)
        {
            try
            {
                // var dataModel = _dataService.Read(viewModel.PackageId);

                if (viewModel.ImageDocument.tempDocumentId > 0)
                {
                    viewModel.Image = viewModel.ImageDocument.tempDocumentId;
                } 
                else if (viewModel.ImageDocument.tempDocumentId == 0 && !viewModel.ImageDocument.documentId.HasValue)
                {
                    viewModel.Image = null;
                }

                base.Update(viewModel);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public override PricePackage Read(long id)
        {
            var viewModel = base.Read(id);

            viewModel.ImageDocument = new Overtech.ViewModels.Document.DocumentHandle { isEmpty = true };
            if (viewModel.Image.HasValue)
            {
                var document = _documentService.Read(viewModel.Image.Value);
                viewModel.ImageDocument.documentId = document.DocumentId;
                viewModel.ImageDocument.fileName = document.Name;
                viewModel.ImageDocument.isEmpty = false;
                viewModel.ImageDocument.isLoading = false;
                viewModel.ImageDocument.itemId = id;
                viewModel.ImageDocument.itemParameterName = "pricePackageId";
                viewModel.ImageDocument.tempDocumentId = 0;
            }
           
            return viewModel;
        }

        [HttpGet]
        [OTControllerAction("Read")]
        [AllowAnonymous]
        public IHttpActionResult DownloadDocument(long pricePackageId, long documentId)
        {
            try
            {
                var pricePackage = _dataService.Read(pricePackageId);
                Overtech.DataModels.Document.Document document = null;
                if (pricePackage.Image.HasValue && pricePackage.Image.Value == documentId)
                {
                    document = _documentService.Read(documentId);
                }
                

                if (document != null)
                {
                    var documentBody = _documentService.GetDocumentBody(document);

                    var result = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(documentBody)
                    };

                    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = document.Name
                    };

                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                    return ResponseMessage(result);
                }


                throw new OTException(-1, "Document Not Found");

            }
            catch (Exception ex)
            {
                _logger.Error(PrepareExceptionMessage(MethodBase.GetCurrentMethod().Name), ex);
                return Content(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
        [HttpDelete]
        [OTControllerAction("Update")]
        public IHttpActionResult DeleteDocument(long pricePackageId, long documentId)
        {
            try
            {
                var pricePackage = _dataService.Read(pricePackageId);

                Overtech.DataModels.Document.Document document = null;

                if (pricePackage.Image.HasValue && pricePackage.Image.Value == documentId)
                {
                    pricePackage.Image = null;
                    document = _documentService.Read(documentId);
                }             

                if (document != null)
                {
                    _dataService.Update(pricePackage);
                    _documentService.Delete(documentId);
                    return Ok();
                }


                throw new OTException(-1, "Document Not Found");
            }
            catch (Exception ex)
            {
                _logger.Error(PrepareExceptionMessage(MethodBase.GetCurrentMethod().Name), ex);
                return Content(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        [HttpGet]
        [Route("GetImageContent")]
        [OTControllerAction("Read")]
        public byte[] GetImageContent(long imageId)
        {
            var document = _documentService.Read(imageId);
            return _documentService.GetDocumentBody(document);
        }


        #endregion Customized

        /*Section="ClassFooter"*/
    }
}