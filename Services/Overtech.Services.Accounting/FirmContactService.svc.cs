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
using Overtech.Core.Application;

/*Section="ClassHeader"*/
namespace Overtech.Services.Accounting
{
    [OTInspectorBehavior]
    public class FirmContactService : CRUDRDataService<Overtech.DataModels.Accounting.FirmContact>, IFirmContactService
    {
        /*Section="Constructor-1"*/
        public FirmContactService()
        {
        }

        /*Section="Constructor-2"*/
        internal FirmContactService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        public IEnumerable<DataModels.Accounting.FirmContact> ListAllContactByFirmId(int firmId)
        {
            List<FirmContact> contactList = null;

            using (IDAL dal = this.DAL)
            {
                IUniParameter prmFirm = dal.CreateParameter("Firm", firmId);
                IUniParameter prmNullContact = dal.CreateParameter("Contact", null);
                contactList = dal.List<FirmContact>("ACC_LST_FIRMCONTACT_SP", prmFirm, prmNullContact).ToList();

                foreach(FirmContact c in contactList)
                {
                    IUniParameter prmContact = dal.CreateParameter("ContactId", c.Contact);
                    c.ContactObject = dal.Read<DataModels.Contact.Contact>("CNT_SEL_CONTACT_SP", prmContact);
                    

                    switch (c.ContactObject.MainContactType)
                    {
                        case 1:
                            c.ContactObject.AddressContact = dal.Read<DataModels.Contact.Address>("CNT_SEL_ADDRESSCONTACT_SP", prmContact);
                            break;
                        case 2:
                            c.ContactObject.PhoneContact = dal.Read<DataModels.Contact.Phone>("CNT_SEL_PHONECONTACT_SP", prmContact);
                            break;
                        case 3:
                            c.ContactObject.WebContact = dal.Read<DataModels.Contact.Web>("CNT_SEL_WEBCONTACT_SP", prmContact);
                            break;
                        default:
                            break;
                    }
                }
            }
                
            return contactList;
        }

        public override FirmContact Create(FirmContact dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    var organization = OTApplication.Context.Organization.Id;
                    dataObject.ContactObject.Organization = organization;
                    long contactId = dal.Create<DataModels.Contact.Contact>(dataObject.ContactObject);

                    switch (dataObject.ContactObject.MainContactType)
                    {
                        case 1:
                            dataObject.ContactObject.AddressContact.Organization = organization;
                            dataObject.ContactObject.AddressContact.Contact = contactId;
                            dal.Create<DataModels.Contact.Address>(dataObject.ContactObject.AddressContact);
                            break;
                        case 2:
                            dataObject.ContactObject.PhoneContact.Organization = organization;
                            dataObject.ContactObject.PhoneContact.Contact = contactId;
                            dal.Create<DataModels.Contact.Phone>(dataObject.ContactObject.PhoneContact);
                            break;
                        case 3:
                            dataObject.ContactObject.WebContact.Organization = organization;
                            dataObject.ContactObject.WebContact.Contact = contactId;
                            dal.Create<DataModels.Contact.Web>(dataObject.ContactObject.WebContact);
                            break;
                        default:
                            break;
                    }
                    dataObject.Contact = contactId;
                    long objectId = dal.Create<FirmContact>(dataObject);
                    dal.CommitTransaction();
                    
                    dataObject.SetId(objectId);
                    return dataObject;
                }
                catch
                {
                    dal.RollbackTransaction();
                    throw;
                }
            }
        }

        public override void Update(FirmContact dataObject)
        {
            using (IDAL dal = this.DAL)
            {
                dal.BeginTransaction();
                try
                {
                    // Update via DAL
                    dal.Update<FirmContact>(dataObject);
                    dal.Update<DataModels.Contact.Contact>(dataObject.ContactObject);

                    switch (dataObject.ContactObject.MainContactType)
                    {
                        case 1:
                            dal.Update<DataModels.Contact.Address>(dataObject.ContactObject.AddressContact);
                            break;
                        case 2:
                            dal.Update<DataModels.Contact.Phone>(dataObject.ContactObject.PhoneContact);
                            break;
                        case 3:
                            dal.Update<DataModels.Contact.Web>(dataObject.ContactObject.WebContact);
                            break;
                        default:
                            break;
                    }
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