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
namespace Overtech.ViewModels.OverStoreMain
{
    [OTDisplayName("Task Document")]
    [DataContract]
    public class TaskDocument : RelationViewModelObject
    {
        private long _overStoreTask;
        private long _document;
        private DateTime _createDate;
        private long _createUser;
        private long _createChannel;
        private long _createBranch;
        private long _createScreen;
        private long _overStoreTaskOverStoreTaskId;
        private string _documentName;

        /*Section="Field-OverStoreTask"*/
        [UIHint("OverStoreTaskList")]
        [OTRequired("OverStore Task", null)]
        [OTDisplayName("OverStore Task")]
        [DataMember]
        public long OverStoreTask
        {
            get
            {
                return _overStoreTask;
            }
            set
            {
                _overStoreTask = value;
            }
        }

        /*Section="Field-Document"*/
        [UIHint("DocumentList")]
        [OTRequired("Document", null)]
        [OTDisplayName("Document")]
        [DataMember]
        public long Document
        {
            get
            {
                return _document;
            }
            set
            {
                _document = value;
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

        /*Section="Field-CreateChannel"*/
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Channel")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Branch")]
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
        [ScaffoldColumn(false)]
        [OTDisplayName("Create Screen")]
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
        #region Parent Name Fields
        /*Section="Field-LeftParentName"*/
        [OTDisplayName("OverStoreTask OverStoreTaskId")]
        [DataMember]
        public long OverStoreTaskOverStoreTaskId
        {
            get
            {
                return _overStoreTaskOverStoreTaskId;
            }
            set
            {
                _overStoreTaskOverStoreTaskId = value;
            }
        }

        /*Section="Field-RightParentName"*/
        [OTDisplayName("Document Name")]
        [DataMember]
        public string DocumentName
        {
            get
            {
                return _documentName;
            }
            set
            {
                _documentName = value;
            }
        }
        #endregion Parent Name Fields

        /*Section="Method-SetLeftId"*/
        public override void SetLeftId(long leftId)
        {
            _overStoreTask = leftId;
        }

        /*Section="Method-SetRightId"*/
        public override void SetRightId(long rightId)
        {
            _document = rightId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}