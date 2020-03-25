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
using Overtech.ServiceContracts.OverStoreMain;
using Overtech.ViewModels.Document;

// Process usings
using Overtech.Core;
using System.Web.Http.ModelBinding;
using System;
using System.Reflection;
using System.Data;

// Document usings
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using Overtech.ServiceContracts.Document;
using Overtech.Shared.Parameter;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.OverStoreMain
{
    [RoutePrefix("api/OverStoreMain/OverStoreTask")]
    public class OverStoreTaskController : CRUDLApiController<Overtech.DataModels.OverStoreMain.OverStoreTask, IOverStoreTaskService, Overtech.ViewModels.OverStoreMain.OverStoreTask>
    {
        IFolderService _folderService;
        IDocumentService _documentService;
        IParameterReader _parameterReader;

        /*Section="Constructor"*/
        public OverStoreTaskController(
            ILoggerFactory loggerFactory,
            IOverStoreTaskService overStoreTaskService,
            IFolderService folderService,
            IDocumentService documentService,
            IParameterReader parameterReader)
            : base(loggerFactory, overStoreTaskService)
        {
            _folderService = folderService;
            _documentService = documentService;
            _parameterReader = parameterReader;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        IMapperConfig mapperConfig = MapperConfig.Init()
                                     .CreateMap<Overtech.DataModels.OverStoreMain.OverStoreTask, Overtech.ViewModels.OverStoreMain.OverStoreTask>()
                                     .CreateMap<Overtech.ViewModels.Document.DocumentBody, Overtech.DataModels.Document.DocumentBody>()
                                     .CreateMap<Overtech.ViewModels.Document.Document, Overtech.DataModels.Document.Document>()
                                     .CreateMap<Overtech.ViewModels.Document.DocumentExtended, Overtech.DataModels.Document.DocumentExtended>();

        public override Overtech.ViewModels.OverStoreMain.OverStoreTask Create([FromBody] Overtech.ViewModels.OverStoreMain.OverStoreTask viewModel)
        {
            var documentList = new List<Overtech.DataModels.Document.Document>();
            long folderId = viewModel.FolderHandle.tempFolderId;
            if (viewModel.FolderHandle.folderId.HasValue)
            {
                folderId = viewModel.FolderHandle.folderId.Value;
            }

            if (folderId > 0)
            {
                viewModel.Folder = folderId;
                foreach (var documentHandle in viewModel.FolderHandle.documents)
                {
                    if (documentHandle.tempDocumentId > 0)
                    {
                        var document = _documentService.Read(documentHandle.tempDocumentId);
                        documentList.Add(document);
                    }
                }
            }
           DataModels.OverStoreMain.OverStoreTask dataModel = viewModel.Map<DataModels.OverStoreMain.OverStoreTask, ViewModels.OverStoreMain.OverStoreTask>(mapperConfig);

           dataModel.DocumentList = documentList;

            return _dataService.Create(dataModel).Map<DataModels.OverStoreMain.OverStoreTask, ViewModels.OverStoreMain.OverStoreTask>(mapperConfig);
        }

        public override void Update(ViewModels.OverStoreMain.OverStoreTask viewModel)
        {
            DataModels.OverStoreMain.OverStoreTask dataModel = viewModel.Map<DataModels.OverStoreMain.OverStoreTask, ViewModels.OverStoreMain.OverStoreTask>(mapperConfig);

            var documentList = new List<Overtech.DataModels.Document.Document>();
            foreach (var documentHandle in viewModel.FolderHandle.documents)
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

        public override ViewModels.OverStoreMain.OverStoreTask Read(long id)
        {
            var viewModel = base.Read(id);
            var documents = new List<DocumentHandle>();
            viewModel.FolderHandle = new FolderHandle()
            {
                isEmpty = true,
                isLoading = false,
                itemParameterName = "folderId",
                tempFolderId = 0,
            };
            if (viewModel.Folder > 0)
            {
                var tempDocumentTypeId = ParameterReader.ReadSystemParameter<long>("TempDocumentType");
                viewModel.FolderHandle.folderId = viewModel.Folder;
                var documentList = _folderService.ListDocuments(viewModel.FolderHandle.folderId.Value);

                if (documentList.Count() > 0)
                {
                    viewModel.FolderHandle.isEmpty = false;
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
                                itemParameterName = "folderId",
                                tempDocumentId = 0
                            };
                            documents.Add(documentHandle);
                        }
                    }

                }
            }
            viewModel.FolderHandle.documents = documents;
            return viewModel;
        }

        [HttpPut]
        [Route("TakeAction")]
        [OTControllerAction("Update")]
        public void TakeAction([FromBody] ViewModels.OverStoreMain.OverStoreTask viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapperConfig = MapperConfig.Init();

                    mapperConfig.CreateMap<DataModels.OverStoreMain.OverStoreTask, ViewModels.OverStoreMain.OverStoreTask>();
                    DataModels.OverStoreMain.OverStoreTask dataModel = viewModel.Map<DataModels.OverStoreMain.OverStoreTask, ViewModels.OverStoreMain.OverStoreTask>(mapperConfig);

                    _dataService.TakeAction(dataModel, viewModel.action, viewModel.actionChoice, viewModel.actionComment);

                }
                catch (Exception ex)
                {
                    _logger.Error(PrepareExceptionMessage(MethodBase.GetCurrentMethod().Name), ex);
                    throw CreateUserException(ex);
                }
            }
            else
            {
                var errors = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                throw CreateUserException(new OTException(OTErrors.ModelStateInvalid, true, null, errors));
            }
        }

        [HttpGet]
        [OTControllerAction("Read")]
        [AllowAnonymous]
        public IHttpActionResult DownloadDocument(long folderId, long documentId)
        {
            try
            {
                var dataItem = _dataService.Read(folderId);
                if (dataItem.Folder.HasValue)
                {
                    var documentList = _folderService.ListDocuments(dataItem.Folder.Value);
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
        public IHttpActionResult DeleteDocument(long folderId, long documentId)
        {
            try
            {
                var dataItem = _dataService.Read(folderId);
                if (dataItem.Folder.HasValue)
                {
                    var documentList = _folderService.ListDocuments(dataItem.Folder.Value);
                    var document = documentList.FirstOrDefault(d => d.DocumentId == documentId);

                    if (document != null)
                    {
                        _documentService.RemoveDocument(dataItem.Folder.Value, document.Name);
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