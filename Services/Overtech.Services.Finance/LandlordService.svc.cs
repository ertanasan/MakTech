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

/*Section="ClassHeader"*/
namespace Overtech.Services.Finance
{
    [OTInspectorBehavior]
    public class LandlordService : CRUDLDataService<Overtech.DataModels.Finance.Landlord>, ILandlordService
    {
        /*Section="Constructor-1"*/
        public LandlordService()
        {
        }

        /*Section="Constructor-2"*/
        internal LandlordService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Finance.Landlord Find(string landlordName)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmLandlordName = dal.CreateParameter("LandlordName", landlordName);
                return dal.Read<Overtech.DataModels.Finance.Landlord>("FIN_SEL_FINDLANDLORD_SP", prmLandlordName);
            }
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
        public EstateLandlord ReadEstateLandlord(long landlord, long estateRent)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmLandlord = dal.CreateParameter("Landlord", landlord);
                IUniParameter prmEstateRent = dal.CreateParameter("EstateRent", estateRent);
                return dal.Read<EstateLandlord>("FIN_SEL_ESTATELANDLORD_SP", prmLandlord, prmEstateRent);
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
        public void DeleteEstateLandlord(long landlord, long estateRent)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmLandlord = dal.CreateParameter("Landlord", landlord);
                    IUniParameter prmEstateRent = dal.CreateParameter("EstateRent", estateRent);
                    dal.ExecuteNonQuery("FIN_DEL_ESTATELANDLORD_SP", prmLandlord, prmEstateRent);
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
        public IEnumerable<EstateLandlord> ListEstateLandlords(long landlordId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmLandlord = dal.CreateParameter("Landlord", landlordId);
                IUniParameter prmEstateRent = dal.CreateParameter("EstateRent", null);
                return dal.List<EstateLandlord>("FIN_LST_ESTATELANDLORD_SP", prmLandlord, prmEstateRent).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public IEnumerable<DataModels.Finance.LandlordMikro> ListAllLandlordsFromMikro()
        {
            using (IDAL dal = this.DAL)
            {
                return dal.List<LandlordMikro>("FIN_LST_LANDLORDMIKRO_SP").ToList();
            }
        }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}