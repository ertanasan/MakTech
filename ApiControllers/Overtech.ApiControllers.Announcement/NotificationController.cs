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
using Overtech.ServiceContracts.Announcement;

// Usings for Document operations
using Overtech.ViewModels.Document;
using Overtech.ServiceContracts.Document;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System;
using System.Reflection;
using Overtech.Core;

/*Section="ClassHeader"*/
namespace Overtech.ApiControllers.Announcement
{
    [RoutePrefix("api/Announcement/Notification")]
    public class NotificationController : CRUDLApiController<Overtech.DataModels.Announcement.Notification, INotificationService, Overtech.ViewModels.Announcement.Notification>
    {
        IFolderService _folderService;
        IDocumentService _documentService;

        /*Section="Constructor"*/
        public NotificationController(
            ILoggerFactory loggerFactory,
            INotificationService notificationService,
            IFolderService folderService,
            IDocumentService documentService)
            : base(loggerFactory, notificationService)
        {
            _folderService = folderService;
            _documentService = documentService;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        private IMapperConfig notificationCreatedMapperConfig()
        {
            return MapperConfig.Init()
                     .CreateMap<Overtech.DataModels.Announcement.Notification, Overtech.ViewModels.Announcement.Notification>()
                     .CreateMap<Overtech.ViewModels.Document.DocumentBody, Overtech.DataModels.Document.DocumentBody>()
                     .CreateMap<Overtech.ViewModels.Document.Document, Overtech.DataModels.Document.Document>()
                     .CreateMap<Overtech.ViewModels.Document.DocumentExtended, Overtech.DataModels.Document.DocumentExtended>();
        }

        [HttpPut]
        [Route("PublishNotification")]
        [OTControllerAction("Update")]
        public void PublishNotification(ViewModels.Announcement.Notification notification)
        {
            _dataService.PublishNotification(notification.Map<DataModels.Announcement.Notification, ViewModels.Announcement.Notification>());
        }

        [HttpGet]
        [Route("GetUserNotifications")]
        [OTControllerAction("List")]
        public IEnumerable<ViewModels.Announcement.Notification> GetUserNotifications(string isSystemNotificationsIncluded)
        {
            return _dataService.GetUserNotifications(isSystemNotificationsIncluded).Map<DataModels.Announcement.Notification, ViewModels.Announcement.Notification>();
        }

        public override ViewModels.Announcement.Notification Create([FromBody] ViewModels.Announcement.Notification viewModel)
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

            IMapperConfig mapperConfig = notificationCreatedMapperConfig();
            DataModels.Announcement.Notification dataModel = viewModel.Map<DataModels.Announcement.Notification, ViewModels.Announcement.Notification>(mapperConfig);

            dataModel.DocumentList = documentList;

            return _dataService.Create(dataModel).Map<DataModels.Announcement.Notification, ViewModels.Announcement.Notification>(mapperConfig);
        }

        public override void Update(ViewModels.Announcement.Notification viewModel)
        {
            IMapperConfig mapperConfig = notificationCreatedMapperConfig();
            DataModels.Announcement.Notification dataModel = viewModel.Map<DataModels.Announcement.Notification, ViewModels.Announcement.Notification>(mapperConfig);

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

        public override ViewModels.Announcement.Notification Read(long id)
        {
            var viewModel = base.Read(id);
            var documents = new List<DocumentHandle>();
            viewModel.FolderHandle = new FolderHandle()
            {
                isEmpty = true,
                isLoading = false,
                itemParameterName = "notificationFolderId",
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
                                itemParameterName = "notificationFolderId",
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

        [HttpGet]
        [OTControllerAction("Read")]
        [AllowAnonymous]
        public IHttpActionResult DownloadDocument(long notificationFolderId, long documentId)
        {
            try
            {
                var contract = _dataService.Read(notificationFolderId);
                if (contract.Folder.HasValue)
                {
                    var documentList = _folderService.ListDocuments(contract.Folder.Value);
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

                        _dataService.CreateLogForDownload(documentId);

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
        public IHttpActionResult DeleteDocument(long notificationFolderId, long documentId)
        {
            try
            {
                var estateRent = _dataService.Read(notificationFolderId);
                if (estateRent.Folder.HasValue)
                {
                    var documentList = _folderService.ListDocuments(estateRent.Folder.Value);
                    var document = documentList.FirstOrDefault(d => d.DocumentId == documentId);

                    if (document != null)
                    {
                        _documentService.RemoveDocument(estateRent.Folder.Value, document.Name);
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