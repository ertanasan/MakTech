// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class CancelReason extends ModelBase {
    public CancelReasonId = 0;
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
    public StoreReconciliation: number;
    public SaleDetail: number;
    public ReasonText: string;
    public CashierName: string;

    public SaleTransactionTime?: Date;
    public SaleCashRegister?: number;
    public ProductCodeName?: string;
    public ProductName?: string;
    public Price?: number;
    public Store?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.CancelReasonId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.CancelReasonId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
