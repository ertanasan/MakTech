// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class StoreReconciliation extends ModelBase {
    public StoreReconciliationId = 0;
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
    public TransactionDate: Date;
    public StoreID: number;
    public PreviousDayAmount: number;
    public SaleTotal: number;
    public CashTotal: number;
    public CardTotal: number;
    public ToBank: number;
    public Difference: number;
    public DifferenceExplanation?: string;
    public Completed: number;
    public EodAdvance: number;
    public Reconciliated = false;
    public Approved = false;
    public StoreName?: string;
    public LastReconciliationDate?: Date;
    public AssaignedAdvance?: number;
    public ZetCount?: number;
    public UserFullName?: string;
    public MissingReconciliation = false;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StoreReconciliationId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StoreReconciliationId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
