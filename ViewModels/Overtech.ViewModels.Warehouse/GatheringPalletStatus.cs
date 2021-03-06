﻿// Created by OverGenerator
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
namespace Overtech.ViewModels.Warehouse
{
    [OTDisplayName("Gathering Pallet Status")]
    [DataContract]
    public class GatheringPalletStatus : ViewModelObject
    {
        private long _statusId;
        private string _name;

        /*Section="Field-StatusId"*/
        [OTRequired("Status Id", null)]
        [OTDisplayName("Status Id")]
        [DataMember]
        public long StatusId
        {
            get
            {
                return _statusId;
            }
            set
            {
                _statusId = value;
            }
        }

        /*Section="Field-Name"*/
        [OTRequired("Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Name")]
        [DataMember]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _statusId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}