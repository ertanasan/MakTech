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
namespace Overtech.ViewModels.StoreUpload
{
    [OTDisplayName("StoreMissingDays")]
    [DataContract]
    public class StoreMissingDays : ViewModelObject
    {
        [DataMember]
        public long StoreId
        {
            get; set;
        }

        [DataMember]
        public string StoreName
        {
            get; set;
        }

        [DataMember]
        public DateTime MissingDay
        {
            get; set;
        }

        [DataMember]
        public string CashRegisterType
        {
            get; set;
        }

        [DataMember]
        public string SaleFilePath1
        {
            get; set;
        }

        [DataMember]
        public string SaleFilePath2
        {
            get; set;
        }

        [DataMember]
        public string SaleFilePath3
        {
            get; set;
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return 0;
        }


    }
}