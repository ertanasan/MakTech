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
namespace Overtech.ViewModels.Sale
{
    [OTDisplayName("Pos Bank Type")]
    [DataContract]
    public class PosBankType : ViewModelObject
    {
        private long _posBankTypeId;
        private string _bankType;

        /*Section="Field-PosBankTypeId"*/
        [OTRequired("Pos Bank Type Id", null)]
        [OTDisplayName("Pos Bank Type Id")]
        [DataMember]
        public long PosBankTypeId
        {
            get
            {
                return _posBankTypeId;
            }
            set
            {
                _posBankTypeId = value;
            }
        }

        /*Section="Field-BankType"*/
        [OTRequired("Bank Type", null)]
        [OTStringLength(100)]
        [OTDisplayName("Bank Type")]
        [DataMember]
        public string BankType
        {
            get
            {
                return _bankType;
            }
            set
            {
                _bankType = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _posBankTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}