// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Loomis extends ModelBase {
    public LoomisId = 0;
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
    public SaleDate: Date;
    public Store: number;
    public SealNo: string;
    public DeclaredAmount?: number;
    public ActualAmount: number;
    public FakeAmount?: number;
    public Explanation?: string;
    public MikroTime?: Date;
    public MikroStatusCode: number;
    public MikroTransactionCode?: string;
    public LoomisDate?: Date;

    public ReconciliationBankAmount?: number;
    public ActualDiff?: number;
    public ControlCode?: number;
    public ReconciliationDiff?: number;
    public ReconDeclaredDiff?: number;

    public CumulativeDiff?: number;
    public CumulativeNegativeDiff?: number;
    public ConsistentDayCount?: number;
    public DayCount?: number;


    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.LoomisId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.LoomisId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}

export class MikroTransferLoomisListModel {
    public SaleDate: Date;
    public LoomisIdList: number[];
}
