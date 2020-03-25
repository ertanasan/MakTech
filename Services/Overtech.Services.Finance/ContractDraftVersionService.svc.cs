// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Finance;
using Overtech.ServiceContracts.Finance;
using Overtech.Mutual.DocumentManagement;
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;
using Overtech.DataModels.Document;

/*Section="ClassHeader"*/
namespace Overtech.Services.Finance
{
    [OTInspectorBehavior]
    public class ContractDraftVersionService : CRUDLDataService<Overtech.DataModels.Finance.ContractDraftVersion>, IContractDraftVersionService
    {
        IParameterReader _parameterReader;
        IOTResolver _resolver;

        /*Section="Constructor-1"*/
        public ContractDraftVersionService(IParameterReader parameterReader, IOTResolver resolver)
        {
            this._parameterReader = parameterReader;
            _resolver = resolver;
        }

        /*Section="Constructor-2"*/
        internal ContractDraftVersionService(IDAL dal)
            : base(dal)
        {
        }
        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public override ContractDraftVersion Create(ContractDraftVersion dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    var documentOperations = new DocumentOperations(dal, this._resolver);
                    var photoDocumentType = documentOperations.ReadDocumentTypeByName("Rent Contract Draft");


                    //var defaultRepositoryId = _parameterReader.ReadSystemParameter<long>("Default Document Repository Id");
                    //var defaultRepository = dal.Read<Repository>(defaultRepositoryId);

                    dataObject.ContractDraftVersionId = dal.Create(dataObject);

                    if (dataObject.DocumentId > 0)
                    {
                        var draftDocument = dal.Read<Document>(dataObject.DocumentId);
                        draftDocument.DocumentType = photoDocumentType.DocumentTypeId;
                        dal.Update(draftDocument);
                        //documentOperations.ChangeRepository(photoDocument, defaultRepository, false);
                    }

                    dal.CommitTransaction();
                    return dataObject;
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public override void Update(ContractDraftVersion dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    var documentOperations = new DocumentOperations(dal, this._resolver);
                    var photoDocumentType = documentOperations.ReadDocumentTypeByName("Rent Contract Draft");

                    //var defaultRepositoryId = _parameterReader.ReadSystemParameter<long>("Default Document Repository Id");
                    //var defaultRepository = dal.Read<Repository>(defaultRepositoryId);

                    if (dataObject.DocumentId > 0)
                    {
                        var draftDocument = dal.Read<Document>(dataObject.DocumentId);
                        draftDocument.DocumentType = photoDocumentType.DocumentTypeId;
                        dal.Update(draftDocument);
                        //if (photoDocument.Repository != defaultRepository.RepositoryId)
                        //{
                        //    documentOperations.ChangeRepository(photoDocument, defaultRepository, false);
                        //}
                    }

                    dal.Update(dataObject);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}