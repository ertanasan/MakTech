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
    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "GATHERINGPALLETPHOTO", HasAutoIdentity = true, DisplayName = "Gathering Pallet Photo", IdField = "GatheringPalletPhotoId")]
    [DataContract]
    public class GatheringPalletPhoto : DataModelObject
    {
        private long _gatheringPalletPhotoId;
        private long _event;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private long _gatheringPallet;
        private long _photo;

        /*Section="Field-GatheringPalletPhotoId"*/
        [OTDataField("GATHERINGPALLETPHOTOID")]
        [DataMember]
        public long GatheringPalletPhotoId
        {
            get
            {
                return _gatheringPalletPhotoId;
            }
            set
            {
                _gatheringPalletPhotoId = value;
            }
        }

        /*Section="Field-Event"*/
        [OTDataField("EVENT")]
        [DataMember]
        public long Event
        {
            get
            {
                return _event;
            }
            set
            {
                _event = value;
            }
        }

        /*Section="Field-Organization"*/
        [OTDataField("ORGANIZATION")]
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

        /*Section="Field-CreateChannel"*/
        [OTDataField("CREATECHANNEL")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateChannel
        {
            get
            {
                return _createChannel;
            }
            set
            {
                _createChannel = value;
            }
        }

        /*Section="Field-CreateBranch"*/
        [OTDataField("CREATEBRANCH")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateBranch
        {
            get
            {
                return _createBranch;
            }
            set
            {
                _createBranch = value;
            }
        }

        /*Section="Field-CreateScreen"*/
        [OTDataField("CREATESCREEN")]
        [ReadOnly(true)]
        [DataMember]
        public long CreateScreen
        {
            get
            {
                return _createScreen;
            }
            set
            {
                _createScreen = value;
            }
        }

        /*Section="Field-GatheringPallet"*/
        [OTDataField("GATHERINGPALLET")]
        [DataMember]
        public long GatheringPallet
        {
            get
            {
                return _gatheringPallet;
            }
            set
            {
                _gatheringPallet = value;
            }
        }

        /*Section="Field-Photo"*/
        [OTDataField("PHOTO")]
        [DataMember]
        public long Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                _photo = value;
            }
        }

        /*Section="Method-SetId"*/
        public override void SetId(long id)
        {
            _gatheringPalletPhotoId = id;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        [DataMember]
        public string PhotoContent { get; set; }

        [OTDataField("PALLET_NO", IsExtended = true)]
        [DataMember]
        public int PalletNo { get; set; }

        [OTDataField("GATHERINGTYPENAME", IsExtended = true)]
        [DataMember]
        public string GatheringTypeName { get; set; }
        #endregion Customized

        /*Section="ClassFooter"*/
    }
}

