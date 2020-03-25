// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Refund extends ModelBase {
    public SaleDetailId = 0;
    public TransactionDate: Date;
    public TransactionTime: Date;
    public TransactionText: string;
    public Unit: number;
    public Quantity: number;
    public Price: number;
    public RefundDescription: string;

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
