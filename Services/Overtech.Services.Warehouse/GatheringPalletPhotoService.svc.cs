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
using Overtech.Mutual.DocumentManagement;
using Overtech.Core.DependencyInjection;
using Overtech.DataModels.Document;

/*Section="ClassHeader"*/
namespace Overtech.Services.Warehouse
{
    [OTInspectorBehavior]
    public class GatheringPalletPhotoService : CRUDLDataService<Overtech.DataModels.Warehouse.GatheringPalletPhoto>, IGatheringPalletPhotoService
    {
        private readonly IOTResolver _resolver;

        /*Section="Constructor-1"*/
        public GatheringPalletPhotoService(IOTResolver resolver)
        {
            _resolver = resolver;
        }

        /*Section="Constructor-2"*/
        internal GatheringPalletPhotoService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public bool UploadPalletPhoto(Overtech.DataModels.Warehouse.GatheringPalletPhoto palletPhoto)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    var photoDocumentId = insertPalletPhotoDocument(palletPhoto, dal);
                    palletPhoto.Photo = photoDocumentId;
                    dal.Create(palletPhoto);
                    dal.CommitTransaction();
                    return true;
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw (ex);
                }
            }
        }

        private long insertPalletPhotoDocument(Overtech.DataModels.Warehouse.GatheringPalletPhoto palletPhoto, IDAL dal)
        {
           try
            {
                var documentOp = new DocumentOperations(dal, _resolver);
                var tmpOrganizastion = palletPhoto.Organization;
                var tmpEvent = palletPhoto.Event;
                var documentTypeId = documentOp.ReadDocumentTypeByName("Gathering Pallet Photo").DocumentTypeId;
                var tmpFilename = "palletPhoto_" + palletPhoto.GatheringPalletPhotoId.ToString() + "_" + DateTime.Now.ToShortDateString();
                var tmpExtension = "png";
                var tmpPhoto = System.Text.Encoding.ASCII.GetBytes(palletPhoto.PhotoContent);

                var tmpDocumentId = documentOp.CreateDocument(tmpOrganizastion, tmpEvent, null, null, documentTypeId, tmpFilename, tmpExtension, tmpPhoto);
                return tmpDocumentId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletePalletPhoto(long gatheringPalletPhotoId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    long documentId = dal.Read<GatheringPalletPhoto>(gatheringPalletPhotoId).Photo;
                    deletePhotoDocument(documentId, dal);
                    dal.Delete<GatheringPalletPhoto>(gatheringPalletPhotoId);
                    dal.CommitTransaction();
                    return true;
                }
                catch (Exception ex)
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        private bool deletePhotoDocument(long documentId, IDAL dal)
        {
            try
            {
                IUniParameter prmDocId = dal.CreateParameter("DocumentId", documentId);
                Document doc = dal.Read<Overtech.DataModels.Document.Document>("DOC_SEL_DOCUMENT_SP", prmDocId);

                var documentOp = new DocumentOperations(dal, _resolver);
                documentOp.DeleteDocument(doc);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Overtech.DataModels.Warehouse.GatheringPalletPhoto> ListPalletPhoto(long storeOrderId, long? gatheringPalletId)
        {
            using (IDAL dal = this.DAL)
            {
                List<Overtech.DataModels.Warehouse.GatheringPalletPhoto> palletPhotos = this.listPalletPhotoByStoreId(dal, storeOrderId, gatheringPalletId);
                var documentOp = new DocumentOperations(dal, _resolver);
                for (int i = 0; i < palletPhotos.Count; i++)
                {
                    IUniParameter prmDocumentId = dal.CreateParameter("DocumentId", palletPhotos[i].Photo);
                    var tmpDocument = dal.Read<Overtech.DataModels.Document.Document>("DOC_SEL_DOCUMENT_SP", prmDocumentId);
                    palletPhotos[i].PhotoContent = System.Text.Encoding.ASCII.GetString(documentOp.GetDocumentBody(tmpDocument));
                }
                return palletPhotos;
            }
        }

        public Overtech.DataModels.Warehouse.GatheringPalletPhoto GetPhotoByIndex(long storeOrderId, int photoIndex, long? gatheringPalletId)
        {
            using (IDAL dal = this.DAL)
            {
                var photoList = this.listPalletPhotoByStoreId(dal, storeOrderId, gatheringPalletId);
                if (photoList.Count() == 0)
                {
                    return null;
                }
                int photoIndexMod = photoIndex % photoList.Count();
                
                Overtech.DataModels.Warehouse.GatheringPalletPhoto selectedPalletPhoto = photoList[photoIndexMod];

                var documentOp = new DocumentOperations(dal, _resolver);
                IUniParameter prmDocumentId = dal.CreateParameter("DocumentId", selectedPalletPhoto.Photo);
                var tmpDocument = dal.Read<Overtech.DataModels.Document.Document>("DOC_SEL_DOCUMENT_SP", prmDocumentId);
                selectedPalletPhoto.PhotoContent = System.Text.Encoding.ASCII.GetString(documentOp.GetDocumentBody(tmpDocument));
                
                return selectedPalletPhoto;
            }
        }

        private List<Overtech.DataModels.Warehouse.GatheringPalletPhoto> listPalletPhotoByStoreId(IDAL dal, long storeOrderId, long? gatheringPalletId)
        {
            IUniParameter prmStoreOrder = dal.CreateParameter("StoreOrder", storeOrderId);
            IUniParameter prmPallet = dal.CreateParameter("GatheringPalletId", gatheringPalletId.HasValue ? gatheringPalletId.Value : (long?)null);
            return dal.List<Overtech.DataModels.Warehouse.GatheringPalletPhoto>("WHS_LST_GATHERINGPALLETPHOTO_SP", prmStoreOrder, prmPallet).ToList();
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}