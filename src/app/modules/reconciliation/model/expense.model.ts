// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Expense extends ModelBase {
    public ExpenseId = 0;
    public Event = 1055;
    public Organization = 1;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public ExpenseType: number;
    public Store?: number;
    public RegionManager?: number;
    public ExpenseDate: Date;
    public ExpenseAmount: number;
    public ReceiptNo?: string;
    public OpenFlag: boolean;
    public PayOffDate?: Date;
    public ExpenseDescription?: string;
    public VATRate: number;
    public MikroTransactionCode?: number;
    public MikroTime?: Date;
    public StatusCode?: number;
    public StatusText?: string;
    public MikroUser?: number;
    public HasReceipt: boolean;
    public StoreName?: string;
    public CreateUserName?: string;
    public UpdateUserName?: string;
    public ExpenseTypeName?: string;
    public RegionManagerName?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ExpenseId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ExpenseId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}

export class MikroTransferListModel {
    public RegionManagerId: number;
    public ExpenseList: string;
}

