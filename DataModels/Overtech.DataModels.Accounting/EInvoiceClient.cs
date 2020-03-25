// Created by OverGenerator
/*Section="Usings"*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Overtech.Core.Data;

/*Section="ClassHeader"*/
namespace Overtech.DataModels.Accounting
{
    [OTDataObject(Module = "Accounting", ModuleShortName = "ACC", Table = "EINVOICECLIENT", HasAutoIdentity = true, DisplayName = "EInvoice Client", IdField = "EInvoiceClientId")]
    [DataContract]
    public class EInvoiceClient : DataModelObject
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
        [OTDataField("EINVOICECLIENTID")]
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
        [OTDataField("IDENTIFIER_NO")]
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
        [OTDataField("ALIAS_DSC")]
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
        [OTDataField("TITLE_DSC")]
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
        [OTDataField("TYPE_NM")]
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
        [OTDataField("FIRSTCREATE_TM", Nullable = true)]
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
        [OTDataField("ALIASCREATE_TM", Nullable = true)]
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
        [OTDataField("EMAIL_TXT")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _eInvoiceClientId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

