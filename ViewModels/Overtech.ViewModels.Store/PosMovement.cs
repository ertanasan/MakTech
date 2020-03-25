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
namespace Overtech.ViewModels.Store
{
    [OTDisplayName("Pos Movement")]
    [DataContract]
    public class PosMovement : ViewModelObject
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
        [ScaffoldColumn(false)]
        [OTRequired("Pos Movement Id", null)]
        [OTDisplayName("Pos Movement Id")]
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
        [UIHint("PosList")]
        [OTRequired("Pos Id", null)]
        [OTDisplayName("Pos Id")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Organization")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Deleted")]
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
        [OTRequired("Move Time", null)]
        [OTDisplayName("Move Time")]
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
        [UIHint("StoreList")]
        [OTRequired("Store", null)]
        [OTDisplayName("Store")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Date")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Update Date")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Create User")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Update User")]
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

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _posMovementId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        [DataMember]
        public int LagStore { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}