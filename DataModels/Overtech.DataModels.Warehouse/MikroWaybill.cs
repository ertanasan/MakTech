using Overtech.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Overtech.DataModels.Warehouse
{

    public enum WarehouseList
    {
        Main = 1001,
        Dispose = 1002,
        Production = 1003,
        Refund = 1004
    }

    public enum TransactionType
    {
        Giris = 0,
        Cikis = 1,
        DepoTransfer = 2
    }

    public enum TransactionKind
    {
        Toptan = 0,
        Perakende = 1,
        DisTicaret = 2,
        StokVirman = 3,
        Fire = 4,
        Sarf = 5,
        Transfer = 6,
        Uretim = 7,
        Fason = 8,
        DegerFarki = 9,
        Sayim = 10,
        StokAcilis = 11,
        IthalatIhracat = 12,
        Hal = 13,
        Mustahsil = 14,
        MustahsilDegerFarki = 15,
        Kabzimal = 16,
        GiderPusulasi = 17
    }

    public enum DocumentType
    {
        DepoCikisFisi = 0,
        CikisIrsaliyesi = 1,
        DepoTransferFisi = 2,
        GirisFaturasi = 3,
        CikisFaturasi = 4,
        StoklaraIthalatMasrafYansitmaDekontu = 5,
        StokVirmanFisi = 6,
        UretimFisi = 7,
        IlaveEnflasyonMaliyetFisi = 8,
        StoklaraIlaveMaliyetYedirmeFisi = 9,
        AntrepolardanMalMillilestirmeFisi = 10,
        AntrepolarArasiTransferFisi = 11,
        DepoGirisFisi = 12,
        GirisIrsaliyesi = 13,
        FasonGirisCikisFisi = 14,
        DepolarArasiSatisFisi = 15,
        StokGiderPusulasiFisi = 16,
        DepolarArasiNakliyeFisi = 17
    }

    [OTDataObject(Module = "Warehouse", ModuleShortName = "WHS", Table = "MIK_TRANSACTION_SYN", HasAutoIdentity = true, DisplayName = "Mikro Waybill", IdField = "sth_Guid")]
    [DataContract]
    public class MikroWaybill : DataModelObject
    {
        [OTDataField("TRANSACTIONDATE", IsExtended = true)]
        [DataMember]
        public DateTime TransactionDate { get; set; }

        [OTDataField("DOCUMENTSERIAL", IsExtended = true)]
        [DataMember]
        public string DocumentSerial { get; set; }

        [OTDataField("DOCUMENTNO", IsExtended = true)]
        [DataMember]
        public int DocumentNo { get; set; }

        [OTDataField("DOCUMENTROWNO", IsExtended = true)]
        [DataMember]
        public int DocumentRowNo { get; set; }

        [OTDataField("DOCUMENTINFO", IsExtended = true)]
        [DataMember]
        public string DocumentInfo { get; set; }

        [OTDataField("TRANSACTIONTYPE", IsExtended = true)]
        [DataMember]
        public int TransactionType { get; set; }

        [OTDataField("TRANSACTIONKIND", IsExtended = true)]
        [DataMember]
        public int TransactionKind { get; set; }

        [OTDataField("ISREFUND", IsExtended = true)]
        [DataMember]
        public bool IsRefund { get; set; }

        [OTDataField("DOCUMENTTYPE", IsExtended = true)]
        [DataMember]
        public int DocumentType { get; set; }

        [OTDataField("DOCUMENTDATE", IsExtended = true)]
        [DataMember]
        public DateTime DocumentDate { get; set; }

        [OTDataField("PRODUCTCODE", IsExtended = true)]
        [DataMember]
        public string ProductCode { get; set; }

        [OTDataField("QUANTITY", IsExtended = true)]
        [DataMember]
        public decimal Quantity { get; set; }

        [OTDataField("VATCODE", IsExtended = true)]
        [DataMember]
        public int VATCode { get; set; }

        [OTDataField("DESCRIPTION", IsExtended = true)]
        [DataMember]
        public string Description { get; set; }

        [OTDataField("RECEIVERWAREHOUSE", IsExtended = true)]
        [DataMember]
        public int ReceiverWarehouse { get; set; }

        [OTDataField("SENDERWAREHOUSE", IsExtended = true)]
        [DataMember]
        public int SenderWarehouse { get; set; }

        [OTDataField("INTAKESHIPMENTDATE", IsExtended = true)]
        [DataMember]
        public DateTime IntakeShipmentDate { get; set; }

        public override void SetId(long id)
        {
        }
    }
}
