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
using System.Data;

/*Section="ClassHeader"*/
namespace Overtech.Services.Accounting
{
    [OTInspectorBehavior]
    public class EInvoiceClientService : CRUDLDataService<Overtech.DataModels.Accounting.EInvoiceClient>, IEInvoiceClientService
    {
        /*Section="Constructor-1"*/
        public EInvoiceClientService()
        {
        }

        /*Section="Constructor-2"*/
        internal EInvoiceClientService(IDAL dal)
            : base(dal)
        {
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        public EInvoiceClient readEInvoice (long IdNo)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmIdNo = dal.CreateParameter("IdNo", IdNo);
                IEnumerable<EInvoiceClient> result = dal.List<EInvoiceClient>("ACC_SEL_EINVOICECLIENTFROMID_SP", prmIdNo).ToList();
                if (result.Count() > 0)
                {
                    return result.First();
                } else
                {
                    return null;
                }

            }
        }

        public IdentityInfo ReadIdentityNo(string IdentityNo)
        {
            using (IDAL dal = this.DAL)
            {
                IUniParameter prmIdentityNo = dal.CreateParameter("IdentityNo", IdentityNo);
                return dal.Read<IdentityInfo>("ACC_SEL_IDENTITYFROMID_SP", prmIdentityNo);
            }
        }

        #endregion Customized

        /*Section="ClassFooter"*/
    }
}