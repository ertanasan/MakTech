// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class BankPosTransactions extends ModelBase {
    public BankPosTransactionsId = 0;
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
    public Bank: number;
    public StoreRef?: string;
    public PosRef?: string;
    public BlockedDate: Date;
    public ValueDate?: Date;
    public Quantity?: number;
    public CreditAmount: number;
    public DebitAmount: number;
    public CommissionAmount: number;
    public MikroTransferTime?: Date;
    public MikroStatusCode: number;
    public MikroTransactionCode?: string;
    public Store?: number;
    public StoreName?: string;
    public RowNo?: number;
    public ReconciliationCardAmount?: number;
    public ControlCode?: number;
    public StoreDiffAmount?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.BankPosTransactionsId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.BankPosTransactionsId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}

export class MikroTransferListModel {
    public BlockedDate: Date;
    public BankPosTransactionsIdList: number[];
}
