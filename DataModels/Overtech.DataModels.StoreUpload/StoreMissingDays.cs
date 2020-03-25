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
namespace Overtech.DataModels.StoreUpload
{
    [OTDataObject(Module = "StoreUpload", ModuleShortName = "SUP", Table = "STOREMISSINGDAYS", HasAutoIdentity = false, DisplayName = "StoreMissingDays", IdField = "StoreId")]
    [DataContract]
    public class StoreMissingDays : DataModelObject
    {
        [OTDataField("STOREID")]
        [DataMember]
        public long StoreId
        {
            get; set;
        }

        [OTDataField("STORE_NM")]
        [DataMember]
        public string StoreName
        {
            get; set;
        }

        [OTDataField("DATE_DT")]
        [DataMember]
        public DateTime MissingDay
        {
            get; set;
        }

        [OTDataField("TERMINAL")]
        [DataMember]
        public string CashRegisterType
        {
            get; set;
        }

        [OTDataField("SALEFILEPATH1_TXT")]
        [DataMember]
        public string SaleFilePath1
        {
            get; set;
        }

        [OTDataField("SALEFILEPATH2_TXT")]
        [DataMember]
        public string SaleFilePath2
        {
            get; set;
        }

        [OTDataField("SALEFILEPATH3_TXT")]
        [DataMember]
        public string SaleFilePath3
        {
            get; set;
        }


        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
        }

        
    }
}

