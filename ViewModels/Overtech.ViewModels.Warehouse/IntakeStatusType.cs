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
namespace Overtech.ViewModels.Warehouse
{
    [OTDisplayName("Intake Status Type")]
    [DataContract]
    public class IntakeStatusType : ViewModelObject
    {
        private long _intakeStatusTypeId;
        private string _intakeStatusTypeName;

        /*Section="Field-IntakeStatusTypeId"*/
        [OTRequired("Intake Status Type Id", null)]
        [OTDisplayName("Intake Status Type Id")]
        [DataMember]
        public long IntakeStatusTypeId
        {
            get
            {
                return _intakeStatusTypeId;
            }
            set
            {
                _intakeStatusTypeId = value;
            }
        }

        /*Section="Field-IntakeStatusTypeName"*/
        [OTRequired("Intake Status Type Name", null)]
        [OTStringLength(100)]
        [OTDisplayName("Intake Status Type Name")]
        [DataMember]
        public string IntakeStatusTypeName
        {
            get
            {
                return _intakeStatusTypeName;
            }
            set
            {
                _intakeStatusTypeName = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _intakeStatusTypeId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}