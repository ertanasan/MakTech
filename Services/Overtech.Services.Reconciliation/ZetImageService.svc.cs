// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Reconciliation;
using Overtech.ServiceContracts.Reconciliation;
using Overtech.Mutual.DocumentManagement;
using Overtech.Core.DependencyInjection;
using Overtech.DataModels.Document;

/*Section="ClassHeader"*/
namespace Overtech.Services.Reconciliation
{
    [OTInspectorBehavior]
    public class ZetImageService : CRUDLDataService<Overtech.DataModels.Reconciliation.ZetImage>, IZetImageService
    {
        private readonly IOTResolver _resolver;

        /*Section="Constructor-1"*/
        public ZetImageService(IOTResolver resolver)
        {
            _resolver = resolver;
        }

        /*Section="Constructor-2"*/
        internal ZetImageService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public bool UploadZetImage(Overtech.DataModels.Reconciliation.ZetImage zetImage)
        {
            var zetDocumentId = insertZetImageDocument(zetImage);
            zetImage.Document = zetDocumentId;

            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    dal.Create(zetImage);
                    //    IUniParameter prmZetId = dal.CreateParameter("ZetImageId", 4, ParameterDirection.Output, 0);
                    //    IUniParameter prmEvent = dal.CreateParameter("Event", 1);
                    //    IUniParameter prmOrganization = dal.CreateParameter("Organization", zetImage.Organizastion);
                    //    IUniParameter prmReconciliation = dal.CreateParameter("Reconciliation", zetImage.ReconciliationId);
                    //    if (zetImage.CashregisterId != null && zetImage.CashregisterId != 0)
                    //    {
                    //        IUniParameter prmCashRegister = dal.CreateParameter("CashRegister", zetImage.CashregisterId);
                    //        dal.ExecuteDataset("RCL_INS_ZETIMAGE_SP", prmZetId, prmEvent, prmOrganization, prmReconciliation, prmCashRegister);
                    //    }
                    //    else
                    //    {
                    //        dal.ExecuteDataset("RCL_INS_ZETIMAGE_SP", prmZetId, prmEvent, prmOrganization, prmReconciliation);
                    //    }
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

        public long insertZetImageDocument(Overtech.DataModels.Reconciliation.ZetImage zetImage)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    var documentOp = new DocumentOperations(dal, _resolver);
                    var tmpOrganizastion = zetImage.Organization;
                    var tmpEvent = zetImage.Event;
                    var documentTypeId = 18;
                    var tmpFilename = "";
                    if (zetImage.CashRegister != 0 && zetImage.CashRegister != null)
                    {
                        tmpFilename = "zetImage_" + zetImage.CashRegister.ToString() + "_" + DateTime.Now.ToShortDateString();
                    }
                    else
                    {
                        tmpFilename = "zetImage_undefinedCR" + "_" + DateTime.Now.ToShortDateString();
                    }
                    var tmpExtension = "png";
                    var tmpPhoto = System.Text.Encoding.ASCII.GetBytes(zetImage.Photo);

                    var tmpDocumentId = documentOp.CreateDocument(tmpOrganizastion, tmpEvent, null, null, documentTypeId, tmpFilename, tmpExtension, tmpPhoto);

                    dal.CommitTransaction();

                    return tmpDocumentId;
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public bool DeleteZetImage(long zetImageId, long documentId)
        {
            bool deletedDocumentFlag = DeleteZetImageDocument(documentId);
            if (!deletedDocumentFlag)
            {
                return false;
            }
            else
            {
                using (IDAL dal = this.DAL)
                {
                    dal.BeginTransaction();
                    try
                    {
                        dal.Delete<ZetImage>(zetImageId);
                        dal.CommitTransaction();
                        return true;
                    }
                    catch
                    {
                        dal.RollbackTransaction();
                        throw;
                    }
                }
            }
        }

        public bool DeleteZetImageDocument(long documentId)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmDocId = dal.CreateParameter("DocumentId", documentId);
                    Document doc = dal.Read<Overtech.DataModels.Document.Document>("DOC_SEL_DOCUMENT_SP", prmDocId);

                    var documentOp = new DocumentOperations(dal, _resolver);
                    documentOp.DeleteDocument(doc);

                    dal.CommitTransaction();
                    return true;
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public IEnumerable<Overtech.DataModels.Reconciliation.ZetImage> ListZetImages(long reconciliationId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmReconId = dal.CreateParameter("ReconciliationId", reconciliationId);
                List<Overtech.DataModels.Reconciliation.ZetImage> zetImages = dal.List<Overtech.DataModels.Reconciliation.ZetImage>("RCL_SEL_ZETIMAGE_SP", prmReconId).ToList();
                var documentOp = new DocumentOperations(dal, _resolver);
                for (int i = 0; i < zetImages.Count; i++)
                {
                    IUniParameter prmDocumentId = dal.CreateParameter("DocumentId", zetImages[i].Document);
                    var tmpDocument = dal.Read<Overtech.DataModels.Document.Document>("DOC_SEL_DOCUMENT_SP", prmDocumentId);
                    zetImages[i].Photo = System.Text.Encoding.ASCII.GetString(documentOp.GetDocumentBody(tmpDocument));
                }
                return zetImages;
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}