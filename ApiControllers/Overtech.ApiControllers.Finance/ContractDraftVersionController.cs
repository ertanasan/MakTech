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
using Overtech.ServiceContracts.Finance;

using System.Web.Http.ModelBinding;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System;
using System.Reflection;
using Overtech.Core;
using Overtech.ViewModels.Finance;
using Overtech.ViewModels.Document;
using Overtech.ServiceContracts.Document;


/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Finance
{
    [RoutePrefix("api/Finance/ContractDraftVersion")]
    public class ContractDraftVersionController : CRUDLApiController<Overtech.DataModels.Finance.ContractDraftVersion, IContractDraftVersionService, Overtech.ViewModels.Finance.ContractDraftVersion>
    {
        private IDocumentService _documentService;

        /*Section="Constructor"*/
        public ContractDraftVersionController(
            ILoggerFactory loggerFactory,
            IContractDraftVersionService contractDraftVersionService,
            IDocumentService documentService)
            : base(loggerFactory, contractDraftVersionService)
        {
            _documentService = documentService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public override ContractDraftVersion Create([FromBody] ContractDraftVersion viewModel)
        {
            try
            {
                if (viewModel.DraftDocument.tempDocumentId > 0)
                {
                    viewModel.DocumentId = viewModel.DraftDocument.tempDocumentId;
                }
                return base.Create(viewModel);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public override void Update(ContractDraftVersion viewModel)
        {
            try
            {
                // var dataModel = _dataService.Read(viewModel.PackageId);

                if (viewModel.DraftDocument.tempDocumentId > 0)
                {
                    viewModel.DocumentId = viewModel.DraftDocument.tempDocumentId;
                }
                //else if (viewModel.DraftDocument.tempDocumentId == 0 && !viewModel.DraftDocument.documentId.HasValue)
                //{
                //    viewModel.DocumentId = null;
                //}

                base.Update(viewModel);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public override ContractDraftVersion Read(long id)
        {
            var viewModel = base.Read(id);

            viewModel.DraftDocument = new Overtech.ViewModels.Document.DocumentHandle { isEmpty = true };
            if (viewModel.DocumentId > 0)
            {
                var document = _documentService.Read(viewModel.DocumentId);
                viewModel.DraftDocument.documentId = document.DocumentId;
                viewModel.DraftDocument.fileName = document.Name;
                viewModel.DraftDocument.isEmpty = false;
                viewModel.DraftDocument.isLoading = false;
                viewModel.DraftDocument.itemId = id;
                viewModel.DraftDocument.itemParameterName = "draftContractDocumentId";
                viewModel.DraftDocument.tempDocumentId = 0;
            }

            return viewModel;
        }

        [HttpGet]
        [OTControllerAction("Read")]
        [AllowAnonymous]
        public IHttpActionResult DownloadDocument(long draftContractDocumentId, long documentId)
        {
            try
            {
                var contractDraftVersion = _dataService.Read(draftContractDocumentId);
                Overtech.DataModels.Document.Document document = null;
                if (contractDraftVersion.DocumentId > 0 && contractDraftVersion.DocumentId == documentId)
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
        public IHttpActionResult DeleteDocument(long draftContractDocumentId, long documentId)
        {
            try
            {
                var contractDraftVersion = _dataService.Read(draftContractDocumentId);

                Overtech.DataModels.Document.Document document = null;

                if (contractDraftVersion.DocumentId > 0  && contractDraftVersion.DocumentId == documentId)
                {
                    contractDraftVersion.DocumentId = 0;
                    document = _documentService.Read(documentId);
                }

                if (document != null)
                {
                    _dataService.Update(contractDraftVersion);
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
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}