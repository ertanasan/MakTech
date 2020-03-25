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
using Overtech.DataModels.Document;
using Overtech.Mutual.Parameter;
using Overtech.Core.DependencyInjection;

/*Section="ClassHeader"*/
namespace Overtech.Services.Finance
{
    [OTInspectorBehavior]
    public class EstateRentService : CRUDLDataService<Overtech.DataModels.Finance.EstateRent>, IEstateRentService
    {
        IParameterReader _parameterReader;
        IOTResolver _resolver;

        /*Section="Constructor-1"*/
        public EstateRentService(IParameterReader parameterReader,
                                 IOTResolver resolver)
        {
            _parameterReader = parameterReader;
            _resolver = resolver;
        }

        /*Section="Constructor-2"*/
        internal EstateRentService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-CreateEstateLandlord"*/
        public void CreateEstateLandlord(EstateLandlord estateLandlord)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmEstateRent = dal.CreateParameter("EstateRent", estateLandlord.EstateRent);
                    IUniParameter prmLandlord = dal.CreateParameter("Landlord", estateLandlord.Landlord);
                    IUniParameter prmOwnershipRate = dal.CreateParameter("OwnershipRate", estateLandlord.OwnershipRate);
                    IUniParameter prmPaymentRate = dal.CreateParameter("PaymentRate", estateLandlord.PaymentRate);
                    IUniParameter prmIBAN = dal.CreateParameter("IBAN", estateLandlord.IBAN);
                    dal.ExecuteNonQuery("FIN_INS_ESTATELANDLORD_SP", prmEstateRent, prmLandlord, prmOwnershipRate, prmPaymentRate, prmIBAN);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-ReadEstateLandlord"*/
        public EstateLandlord ReadEstateLandlord(long estateRent, long landlord)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmEstateRent = dal.CreateParameter("EstateRent", estateRent);
                IUniParameter prmLandlord = dal.CreateParameter("Landlord", landlord);
                return dal.Read<EstateLandlord>("FIN_SEL_ESTATELANDLORD_SP", prmEstateRent, prmLandlord);
            }
        }

        /*Section="Method-UpdateEstateLandlord"*/
        public void UpdateEstateLandlord(EstateLandlord estateLandlord)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmEstateRent = dal.CreateParameter("EstateRent", estateLandlord.EstateRent);
                    IUniParameter prmLandlord = dal.CreateParameter("Landlord", estateLandlord.Landlord);
                    IUniParameter prmOwnershipRate = dal.CreateParameter("OwnershipRate", estateLandlord.OwnershipRate);
                    IUniParameter prmPaymentRate = dal.CreateParameter("PaymentRate", estateLandlord.PaymentRate);
                    IUniParameter prmIBAN = dal.CreateParameter("IBAN", estateLandlord.IBAN);
                    dal.ExecuteNonQuery("FIN_UPD_ESTATELANDLORD_SP", prmEstateRent, prmLandlord, prmOwnershipRate, prmPaymentRate, prmIBAN);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-DeleteEstateLandlord"*/
        public void DeleteEstateLandlord(long estateRent, long landlord)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmEstateRent = dal.CreateParameter("EstateRent", estateRent);
                    IUniParameter prmLandlord = dal.CreateParameter("Landlord", landlord);
                    dal.ExecuteNonQuery("FIN_DEL_ESTATELANDLORD_SP", prmEstateRent, prmLandlord);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-ListEstateLandlords"*/
        public IEnumerable<EstateLandlord> ListEstateLandlords(long estateRentId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmEstateRent = dal.CreateParameter("EstateRent", estateRentId);
                IUniParameter prmLandlord = dal.CreateParameter("Landlord", null);
                return dal.List<EstateLandlord>("FIN_LST_ESTATELANDLORD_SP", prmEstateRent, prmLandlord).ToList();
            }
        }

        /*Section="Method-ListEstateRentPeriods"*/
        public IEnumerable<EstateRentPeriod> ListEstateRentPeriods(long estateRentId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmEstateRent = dal.CreateParameter("EstateRent", estateRentId);
                return dal.List<EstateRentPeriod>("FIN_LST_ESTATERENTPERIOD_SP", prmEstateRent).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public override EstateRent Create(EstateRent dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    updateDataObjectDocument(dataObject, dal);
                    dal.Create(dataObject);
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

        public override void Update(EstateRent dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    updateDataObjectDocument(dataObject, dal);
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

        private void updateDataObjectDocument(DataModels.Finance.EstateRent dataObject, IDAL dal)
        {
            var documentOperations = new DocumentOperations(dal, this._resolver);
            var documentType = documentOperations.ReadDocumentTypeByName("Estate Rent");
            var tempDocumentTypeId = _parameterReader.ReadSystemParameter<long>("TempDocumentType");
            var defaultRepositoryId = _parameterReader.ReadSystemParameter<long>("Default Document Repository Id");
            var defaultRepository = dal.Read<Repository>(defaultRepositoryId);

            foreach (var document in dataObject.DocumentList)
            {
                if (document.DocumentType == tempDocumentTypeId)
                {
                    document.DocumentType = documentType.DocumentTypeId;
                    dal.Update(document);
                    documentOperations.ChangeRepository(document, defaultRepository, false);
                }
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}