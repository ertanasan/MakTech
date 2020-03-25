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
namespace Overtech.DataModels.Warehouse
{
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "INTAKESTATUSTYPE", HasAutoIdentity = false, DisplayName = "Intake Status Type", IdField = "IntakeStatusTypeId")]
    [DataContract]
    public class IntakeStatusType : DataModelObject
    {
        private long _intakeStatusTypeId;
        private string _intakeStatusTypeName;

        /*Section="Field-IntakeStatusTypeId"*/
        [OTDataField("INTAKESTATUSTYPEID")]
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
        [OTDataField("INTAKESTATUSTYPE_NM")]
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

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _intakeStatusTypeId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}

