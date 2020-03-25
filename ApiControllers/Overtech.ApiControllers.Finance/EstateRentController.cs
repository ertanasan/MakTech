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
using Overtech.Shared.Parameter;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Finance
{
    [RoutePrefix("api/Finance/EstateRent")]
    public class EstateRentController : CRUDLApiController<Overtech.DataModels.Finance.EstateRent, IEstateRentService, Overtech.ViewModels.Finance.EstateRent>
    {
        IFolderService _folderService;
        IDocumentService _documentService;
        IParameterReader _parameterReader;

        /*Section="Constructor"*/
        public EstateRentController(
            ILoggerFactory loggerFactory,
            IEstateRentService estateRentService,
            IFolderService folderService,
            IDocumentService documentService,
            IParameterReader parameterReader)
            : base(loggerFactory, estateRentService)
        {
            _folderService = folderService;
            _documentService = documentService;
            _parameterReader = parameterReader;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        private IMapperConfig estateRentCreatedMapperConfig()
        {
            return MapperConfig.Init()
                     .CreateMap<Overtech.DataModels.Finance.EstateRent, Overtech.ViewModels.Finance.EstateRent>()
                     .CreateMap<Overtech.ViewModels.Document.DocumentBody, Overtech.DataModels.Document.DocumentBody>()
                     .CreateMap<Overtech.ViewModels.Document.Document, Overtech.DataModels.Document.Document>()
                     .CreateMap<Overtech.ViewModels.Document.DocumentExtended, Overtech.DataModels.Document.DocumentExtended>();
        }

        public override EstateRent Create([FromBody] EstateRent viewModel)
        {
            var documentList = new List<Overtech.DataModels.Document.Document>();
            long folderId = viewModel.RentFolderHandle.tempFolderId;
            if (viewModel.RentFolderHandle.folderId.HasValue)
            {
                folderId = viewModel.RentFolderHandle.folderId.Value;
            }

            if (folderId > 0)
            {
                viewModel.ContractFolder = folderId;
                foreach (var documentHandle in viewModel.RentFolderHandle.documents)
                {
                    if (documentHandle.tempDocumentId > 0)
                    {
                        var document = _documentService.Read(documentHandle.tempDocumentId);
                        documentList.Add(document);
                    }
                }
            }
            IMapperConfig mapperConfig = estateRentCreatedMapperConfig();
            DataModels.Finance.EstateRent dataModel = viewModel.Map<DataModels.Finance.EstateRent, ViewModels.Finance.EstateRent>(mapperConfig);

            dataModel.DocumentList = documentList;

            return _dataService.Create(dataModel).Map<DataModels.Finance.EstateRent, ViewModels.Finance.EstateRent>(mapperConfig);
        }

        public override void Update(EstateRent viewModel)
        {
            IMapperConfig mapperConfig = estateRentCreatedMapperConfig();
            DataModels.Finance.EstateRent dataModel = viewModel.Map<DataModels.Finance.EstateRent, ViewModels.Finance.EstateRent>(mapperConfig);

            var documentList = new List<Overtech.DataModels.Document.Document>();
            foreach (var documentHandle in viewModel.RentFolderHandle.documents)
            {
                if (documentHandle.tempDocumentId > 0)
                {
                    var document = _documentService.Read(documentHandle.tempDocumentId);
                    documentList.Add(document);
                }
            }
            dataModel.DocumentList = documentList;
            _dataService.Update(dataModel);
        }

        public override EstateRent Read(long id)
        {
            var viewModel = base.Read(id);
            var documents = new List<DocumentHandle>();
            viewModel.RentFolderHandle = new FolderHandle()
            {
                isEmpty = true,
                isLoading = false,
                itemParameterName = "estateRentFolderId",
                tempFolderId = 0,
            };
            if (viewModel.ContractFolder > 0)
            {
                var tempDocumentTypeId = ParameterReader.ReadSystemParameter<long>("TempDocumentType");
                viewModel.RentFolderHandle.folderId = viewModel.ContractFolder;
                var documentList = _folderService.ListDocuments(viewModel.RentFolderHandle.folderId.Value);

                if (documentList.Count() > 0)
                {
                    viewModel.RentFolderHandle.isEmpty = false;
                    foreach (var document in documentList)
                    {
                        if (document.DocumentType != tempDocumentTypeId)
                        {
                            var documentHandle = new DocumentHandle
                            {
                                documentId = document.DocumentId,
                                fileName = document.Name,
                                isEmpty = false,
                                isLoading = false,
                                itemId = id,
                                itemParameterName = "estateRentFolderId",
                                tempDocumentId = 0
                            };
                            documents.Add(documentHandle);
                        }
                    }

                }
            }
            viewModel.RentFolderHandle.documents = documents;
            return viewModel;
        }

        [HttpGet]
        [OTControllerAction("Read")]
        [AllowAnonymous]
        public IHttpActionResult DownloadDocument(long estateRentFolderId, long documentId)
        {
            try
            {
                var contract = _dataService.Read(estateRentFolderId);
                if (contract.ContractFolder.HasValue)
                {
                    var documentList = _folderService.ListDocuments(contract.ContractFolder.Value);
                    var document = documentList.FirstOrDefault(d => d.DocumentId == documentId);

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
        public IHttpActionResult DeleteDocument(long estateRentFolderId, long documentId)
        {
            try
            {
                var estateRent = _dataService.Read(estateRentFolderId);
                if (estateRent.ContractFolder.HasValue)
                {
                    var documentList = _folderService.ListDocuments(estateRent.ContractFolder.Value);
                    var document = documentList.FirstOrDefault(d => d.DocumentId == documentId);

                    if (document != null)
                    {
                        _documentService.RemoveDocument(estateRent.ContractFolder.Value, document.Name);
                        _documentService.Delete(documentId);
                        return Ok();
                    }
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