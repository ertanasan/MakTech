// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class SaleDetail extends ModelBase {
    public SaleDetailId = 0;
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
    public SaleID: number;
    public TransactionID: string;
    public TransactionDate: Date;
    public Barcode: string;
    public ProductID: number;
    public ProductCode: string;
    public Store: number;
    public Price: number;
    public VATRate: number;
    public Quantity: number;
    public Unit: number;
    public CancelFlag: boolean;
    public UnitPrice: number;
    public ProductName?: string;
    public KgQuantity?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SaleDetailId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.SaleDetailId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
