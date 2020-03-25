// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Price;
using Overtech.ServiceContracts.Price;
using Overtech.Mutual.DocumentManagement;
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;
using Overtech.DataModels.Document;

/*Section="ClassHeader"*/
namespace Overtech.Services.Price
{
    [OTInspectorBehavior]
    public class PricePackageService : CRUDLDataService<Overtech.DataModels.Price.PricePackage>, IPricePackageService
    {
        /*Section="Constructor-1"*/
        IParameterReader _parameterReader;
        IOTResolver _resolver;
        public PricePackageService(IParameterReader parameterReader, IOTResolver resolver)
        {
            this._parameterReader = parameterReader;
            _resolver = resolver;
        }

        /*Section="Constructor-2"*/
        internal PricePackageService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-ListPackageVersions"*/
        public IEnumerable<PackageVersion> ListPackageVersions(long packageId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmPackage = dal.CreateParameter("Package", packageId);
                return dal.List<PackageVersion>("PRC_LST_PACKAGEVERSION_SP", prmPackage).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public PackagePerformance GetPackagePerformance(long packageId)
        {
            using (IDAL dal = this.DAL)
            {
                PackagePerformance pckPrf = new PackagePerformance();
                pckPrf.PackageId = packageId;

                IUniParameter prmPackageId = dal.CreateParameter("PackageId", packageId);
                var prmPriceChangePercentage = dal.CreateParameter("PriceChangePercentage", 4, ParameterDirection.Output, 0.0);
                var prmSaleChangePercentage = dal.CreateParameter("SaleChangePercentage", 4, ParameterDirection.Output, 0.0);
                var prmProductCount = dal.CreateParameter("ProductCount", 2, ParameterDirection.Output, 0);
                pckPrf.PerformanceDetailsGrid = dal.ExecuteDataset("PRC_LST_PRVCAMPAINGPERFORMANCE_SP"
                                                                    , prmPackageId
                                                                    , prmPriceChangePercentage
                                                                    , prmSaleChangePercentage
                                                                    , prmProductCount
                                                                    ).Tables[0];

                pckPrf.PriceChangePercentage = prmPriceChangePercentage.Value.To<float>();
                pckPrf.SaleChangePercentage = prmSaleChangePercentage.Value.To<float>();
                pckPrf.ProductCount = prmProductCount.Value.To<int>();

                return pckPrf;
            }
        }
        
        public override PricePackage Create(PricePackage dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    var documentOperations = new DocumentOperations(dal, this._resolver);
                    var photoDocumentType = documentOperations.ReadDocumentTypeByName("Price Package Photo");
                   

                    //var defaultRepositoryId = _parameterReader.ReadSystemParameter<long>("Default Document Repository Id");
                    //var defaultRepository = dal.Read<Repository>(defaultRepositoryId);

                    dataObject.PackageId = dal.Create(dataObject);

                    if (dataObject.Image.HasValue)
                    {
                        var photoDocument = dal.Read<Document>(dataObject.Image.Value);
                        photoDocument.DocumentType = photoDocumentType.DocumentTypeId;
                        dal.Update(photoDocument);
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

        public override void Update(PricePackage dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    var documentOperations = new DocumentOperations(dal, this._resolver);
                    var photoDocumentType = documentOperations.ReadDocumentTypeByName("Price Package Photo");
                    
                    //var defaultRepositoryId = _parameterReader.ReadSystemParameter<long>("Default Document Repository Id");
                    //var defaultRepository = dal.Read<Repository>(defaultRepositoryId);

                    if (dataObject.Image.HasValue)
                    {
                        var photoDocument = dal.Read<Document>(dataObject.Image.Value);
                        photoDocument.DocumentType = photoDocumentType.DocumentTypeId;
                        dal.Update(photoDocument);
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