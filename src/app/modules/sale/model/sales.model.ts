// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Sales extends ModelBase {
    public SalesId = 0;
    public Event = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public TransactionCode: string;
    public Store: number;
    public CashierCode: string;
    public CashRegister: number;
    public TransactionDate: Date;
    public TransactionTime: Date;
    public VATAmount: number;
    public Total: number;
    public ProductDiscount: number;
    public TotalDiscount: number;
    public ProductCount: number;
    public ProcessDuration: number;
    public Cancelled: boolean;
    public TransactionType: number;
    public InvoiceId: number;
    public TransactionRef?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SalesId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.SalesId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}

export class DeviceInfoModel {
    public DeviceInfo: string;
}
