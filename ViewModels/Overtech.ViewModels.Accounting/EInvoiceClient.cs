// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Overtech.Core.Data;
using Overtech.UI.Data.Annotations;

/*Section="ClassHeader"*/
namespace Overtech.ViewModels.Accounting
{
    [OTDisplayName("EInvoice Client")]
    [DataContract]
    public class EInvoiceClient : ViewModelObject
    {
        private long _eInvoiceClientId;
        private long _identifier;
        private string _alias;
        private string _title;
        private string _type;
        private Nullable<DateTime> _firstCreateTime;
        private Nullable<DateTime> _aliasCreateTime;
        private string _email;

        /*Section="Field-EInvoiceClientId"*/
        [ScaffoldColumn(false)]
        [OTRequired("EInvoice Client Id", null)]
        [OTDisplayName("EInvoice Client Id")]
        [DataMember]
        public long EInvoiceClientId
        {
            get
            {
                return _eInvoiceClientId;
            }
            set
            {
                _eInvoiceClientId = value;
            }
        }

        /*Section="Field-Identifier"*/
        [OTRequired("Identifier", null)]
        [OTDisplayName("Identifier")]
        [DataMember]
        public long Identifier
        {
            get
            {
                return _identifier;
            }
            set
            {
                _identifier = value;
            }
        }

        /*Section="Field-Alias"*/
        [OTRequired("Alias", null)]
        [OTStringLength(200)]
        [OTDisplayName("Alias")]
        [DataMember]
        public string Alias
        {
            get
            {
                return _alias;
            }
            set
            {
                _alias = value;
            }
        }

        /*Section="Field-Title"*/
        [OTRequired("Title", null)]
        [OTStringLength(1000)]
        [OTDisplayName("Title")]
        [DataMember]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        /*Section="Field-Type"*/
        [OTRequired("Type", null)]
        [OTStringLength(50)]
        [OTDisplayName("Type")]
        [DataMember]
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        /*Section="Field-FirstCreateTime"*/
        [OTDisplayName("First Create Time")]
        [DataMember]
        public Nullable<DateTime> FirstCreateTime
        {
            get
            {
                return _firstCreateTime;
            }
            set
            {
                _firstCreateTime = value;
            }
        }

        /*Section="Field-AliasCreateTime"*/
        [OTDisplayName("Alias Create Time")]
        [DataMember]
        public Nullable<DateTime> AliasCreateTime
        {
            get
            {
                return _aliasCreateTime;
            }
            set
            {
                _aliasCreateTime = value;
            }
        }

        /*Section="Field-Email"*/
        [OTRequired("Email", null)]
        [OTDisplayName("Email")]
        [DataMember]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _eInvoiceClientId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}