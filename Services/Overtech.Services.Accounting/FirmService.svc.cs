// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.Linq;

using Overtech.Core;
using Overtech.Service;
using Overtech.Service.Data.Uni;
using Overtech.DataModels.Accounting;
using Overtech.ServiceContracts.Accounting;

/*Section="ClassHeader"*/
namespace Overtech.Services.Accounting
{
    [OTInspectorBehavior]
    public class FirmService : CRUDLDataService<Overtech.DataModels.Accounting.Firm>, IFirmService
    {
        /*Section="Constructor-1"*/
        public FirmService()
        {
        }

        /*Section="Constructor-2"*/
        internal FirmService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="Method-Find"*/
        public Overtech.DataModels.Accounting.Firm Find(string name)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmName = dal.CreateParameter("Name", name);
                return dal.Read<Overtech.DataModels.Accounting.Firm>("ACC_SEL_FINDFIRM_SP", prmName);
            }
        }

        /*Section="Method-CreateFirmContact"*/
        public void CreateFirmContact(FirmContact firmContact)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmFirm = dal.CreateParameter("Firm", firmContact.Firm);
                    IUniParameter prmContact = dal.CreateParameter("Contact", firmContact.Contact);
                    IUniParameter prmIsDefault = dal.CreateParameter("IsDefault", firmContact.IsDefault ? "Y" : "N");
                    IUniParameter prmIsActive = dal.CreateParameter("IsActive", firmContact.IsActive ? "Y" : "N");
                    IUniParameter prmIsPreferred = dal.CreateParameter("IsPreferred", firmContact.IsPreferred ? "Y" : "N");
                    dal.ExecuteNonQuery("ACC_INS_FIRMCONTACT_SP", prmFirm, prmContact, prmIsDefault, prmIsActive, prmIsPreferred);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-ReadFirmContact"*/
        public FirmContact ReadFirmContact(long firm, long contact)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmFirm = dal.CreateParameter("Firm", firm);
                IUniParameter prmContact = dal.CreateParameter("Contact", contact);
                return dal.Read<FirmContact>("ACC_SEL_FIRMCONTACT_SP", prmFirm, prmContact);
            }
        }

        /*Section="Method-UpdateFirmContact"*/
        public void UpdateFirmContact(FirmContact firmContact)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmFirm = dal.CreateParameter("Firm", firmContact.Firm);
                    IUniParameter prmContact = dal.CreateParameter("Contact", firmContact.Contact);
                    IUniParameter prmIsDefault = dal.CreateParameter("IsDefault", firmContact.IsDefault ? "Y" : "N");
                    IUniParameter prmIsActive = dal.CreateParameter("IsActive", firmContact.IsActive ? "Y" : "N");
                    IUniParameter prmIsPreferred = dal.CreateParameter("IsPreferred", firmContact.IsPreferred ? "Y" : "N");
                    dal.ExecuteNonQuery("ACC_UPD_FIRMCONTACT_SP", prmFirm, prmContact, prmIsDefault, prmIsActive, prmIsPreferred);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-DeleteFirmContact"*/
        public void DeleteFirmContact(long firm, long contact)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    IUniParameter prmFirm = dal.CreateParameter("Firm", firm);
                    IUniParameter prmContact = dal.CreateParameter("Contact", contact);
                    dal.ExecuteNonQuery("ACC_DEL_FIRMCONTACT_SP", prmFirm, prmContact);
                    dal.CommitTransaction();
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        /*Section="Method-ListFirmContacts"*/
        public IEnumerable<FirmContact> ListFirmContacts(long firmId)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmFirm = dal.CreateParameter("Firm", firmId);
                IUniParameter prmContact = dal.CreateParameter("Contact", null);
                return dal.List<FirmContact>("ACC_LST_FIRMCONTACT_SP", prmFirm, prmContact).ToList();
            }
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}