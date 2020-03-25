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
namespace Overtech.DataModels.Store
{
    [OTDataObject(Module = "Store", ModuleShortName = "STR", Table = "POSMOVE", HasAutoIdentity = true, DisplayName = "Pos Movement", IdField = "PosMovementId")]
    [DataContract]
    public class PosMovement : DataModelObject
    {
        private long _posMovementId;
        private long _posId;
        private long _organization;
        private bool _deleted;
        private DateTime _moveTime;
        private long _store;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;

        /*Section="Field-PosMovementId"*/
        [OTDataField("POSMOVEID")]
        [DataMember]
        public long PosMovementId
        {
            get
            {
                return _posMovementId;
            }
            set
            {
                _posMovementId = value;
            }
        }

        /*Section="Field-PosId"*/
        [OTDataField("POSID")]
        [DataMember]
        public long PosId
        {
            get
            {
                return _posId;
            }
            set
            {
                _posId = value;
            }
        }

        /*Section="Field-Organization"*/
        [OTDataField("ORGANIZATION")]
        [ReadOnly(true)]
        [DataMember]
        public long Organization
        {
            get
            {
                return _organization;
            }
            set
            {
                _organization = value;
            }
        }

        /*Section="Field-Deleted"*/
        [OTDataField("DELETED_FL")]
        [ReadOnly(true)]
        [DataMember]
        public bool Deleted
        {
            get
            {
                return _deleted;
            }
            set
            {
                _deleted = value;
            }
        }

        /*Section="Field-MoveTime"*/
        [OTDataField("MOVE_TM")]
        [DataMember]
        public DateTime MoveTime
        {
            get
            {
                return _moveTime;
            }
            set
            {
                _moveTime = value;
            }
        }

        /*Section="Field-Store"*/
        [OTDataField("STORE")]
        [DataMember]
        public long Store
        {
            get
            {
                return _store;
            }
            set
            {
                _store = value;
            }
        }

        /*Section="Field-CreateDate"*/
        [OTDataField("CREATE_DT")]
        [ReadOnly(true)]
        [DataMember]
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
            }
        }

        /*Section="Field-UpdateDate"*/
        [OTDataField("UPDATE_DT", Nullable = true)]
        [ReadOnly(true)]
        [DataMember]
        public Nullable<DateTime> UpdateDate
        {
            get
            {
                return _updateDate;
            }
            set
            {
                _updateDate = value;
            }
        }

        /*Section="Field-CreateUser"*/
        [OTDataField("CREATEUSER")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateUser
        {
            get
            {
                return _createUser;
            }
            set
            {
                _createUser = value;
            }
        }

        /*Section="Field-UpdateUser"*/
        [OTDataField("UPDATEUSER", Nullable = true)]
        [ReadOnly(true)]
        [DataMember]
        public Nullable<long> UpdateUser
        {
            get
            {
                return _updateUser;
            }
            set
            {
                _updateUser = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _posMovementId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [OTDataField("LAGSTORE", IsExtended = true)]
        [DataMember]
        public int LagStore { get; set; }
        #endregion Customized
        
    /*Section="ClassFooter"*/
    }
}

