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
    [OTDisplayName("Cashier")]
    [DataContract]
    public class Cashier : ViewModelObject
    {
        private long _cashierId;
        private long _organization;
        private bool _deleted;
        private DateTime _createDate;
        private Nullable<DateTime> _updateDate;
        private long _createUser;
        private Nullable<long> _updateUser;
        private long _store;
        private string _cashierName;
        private long _cashierTemplateNumber;
        private long _cashierTitleNumber;
        private int _password;
        private bool _cashierFlag;
        private bool _isActive;
        private bool _salesman;
        private Nullable<int> _workingType;
        private string _note;

        /*Section="Field-CashierId"*/
        [OTRequired("Cashier  Id", null)]
        [OTDisplayName("Cashier  Id")]
        [DataMember]
        public long CashierId
        {
            get
            {
                return _cashierId;
            }
            set
            {
                _cashierId = value;
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

        /*Section="Field-CashierName"*/
        [OTRequired("Cashier Name", null)]
        [OTStringLength(30)]
        [OTDisplayName("Cashier Name")]
        [DataMember]
        public string CashierName
        {
            get
            {
                return _cashierName;
            }
            set
            {
                _cashierName = value;
            }
        }

        /*Section="Field-CashierTemplateNumber"*/
        [UIHint("CashierTemplateList")]
        [OTRequired("Cashier Template Number", null)]
        [OTDisplayName("Cashier Template Number")]
        [DataMember]
        public long CashierTemplateNumber
        {
            get
            {
                return _cashierTemplateNumber;
            }
            set
            {
                _cashierTemplateNumber = value;
            }
        }

        /*Section="Field-CashierTitleNumber"*/
        [UIHint("TitleList")]
        [OTRequired("Cashier Title Number", null)]
        [OTDisplayName("Cashier Title Number")]
        [DataMember]
        public long CashierTitleNumber
        {
            get
            {
                return _cashierTitleNumber;
            }
            set
            {
                _cashierTitleNumber = value;
            }
        }

        /*Section="Field-Password"*/
        [OTRequired("Password", null)]
        [OTDisplayName("Password")]
        [DataMember]
        public int Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        /*Section="Field-CashierFlag"*/
        [OTRequired("Cashier  Flag", null)]
        [OTDisplayName("Cashier  Flag")]
        [DataMember]
        public bool CashierFlag
        {
            get
            {
                return _cashierFlag;
            }
            set
            {
                _cashierFlag = value;
            }
        }

        /*Section="Field-IsActive"*/
        [OTRequired("Is Active", null)]
        [OTDisplayName("Is Active")]
        [DataMember]
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }

        /*Section="Field-Salesman"*/
        [OTRequired("Salesman", null)]
        [OTDisplayName("Salesman")]
        [DataMember]
        public bool Salesman
        {
            get
            {
                return _salesman;
            }
            set
            {
                _salesman = value;
            }
        }

        /*Section="Field-WorkingType"*/
        [OTDisplayName("Working Type")]
        [DataMember]
        public Nullable<int> WorkingType
        {
            get
            {
                return _workingType;
            }
            set
            {
                _workingType = value;
            }
        }

        /*Section="Field-Note"*/
        [OTDisplayName("Note")]
        [DataMember]
        public string Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
            }
        }

        /*Section="Method-GetId"*/
        public override long GetId()
        {
            return _cashierId;
        }

        /*Section="CustomCodeRegion"*/
        #region Customized
        // Keep your custom code in this region.
        #endregion Customized

    /*Section="ClassFooter"*/
    }
}