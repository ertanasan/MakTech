// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class SaleDailySummary extends ModelBase {
    public SaleDailySummaryId = 0;
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
    public StoreID: number;
    public TransactionDate: Date;
    public ZetNo?: number;
    public ReceiptCount?: number;
    public ReceiptTotal?: number;
    public RefundCount?: number;
    public RefundAmount?: number;
    public CashAmount?: number;
    public CardAmount?: number;
    public CashRegister: number;
    public SlpTotal?: number;
    public SlpCount: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SaleDailySummaryId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.SaleDailySummaryId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
