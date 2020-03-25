// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import { CashDistribution } from './cash-distribution.model';
import { CardDistribution } from './card-distribution.model';
import { RecLog } from './rec-log.model';
import { CancelReason } from '@sale/model/cancel-reason.model';

/*Section="ClassHeader"*/
export class Reconciliation extends ModelBase {
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
    public Store?: number;
    public ReconciliationDate: Date;
    public ZetAmount: number;
    public DefinedAdvance: number;
    public ExpenseAmount?: number;
    public CashAmount: number;
    public CardAmount: number;
    public RecoveredAmount?: number;
    public AdjustmentAmount?: number;
    public NetoffAmount: number;
    public BankAmount: number;
    public CurrentAdvance: number;
    public ExpenseReturn?: number;
    public DiffReasonCodes?: string;
    public DiffReason?: string;
    public LastStepNo?: number;
    public CompleteFlag?: boolean;
    public CashDist?: CashDistribution[];
    public CardDist?: CardDistribution[];
    public RecLog?: RecLog[];
    public CancelReasons?: CancelReason[];
    public CashDeficit?: number;
    public CashSurplus?: number;
    public CumulativeDiff?: number;
    public AdjustmentReason?: string;
    public DeficitCycleCount?: number;
    public LastReconciliationDate?: Date;
    public StoreName?: string;
    public UserName?: string;
    public RegionName?: string;
    public RegionManagerName?: string;
    public TotalOpenExpense?: number;
    public NextDate?: Date;
    public AllowCancel?: boolean;
    public InvoiceTotal?: number;
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

export class ZetImage {
    public ZetImageId = 0;
    public Event = 1;
    public Organization = 0;
    public Deleted = false;
    public CreateDate: Date;
    public UpdateDate?: Date;
    public CreateUser: number;
    public UpdateUser?: number;
    public CreateChannel?: number;
    public CreateBranch?: number;
    public CreateScreen?: number;
    public Reconciliation: number;
    public CashRegister?: number;
    public Document = 0;
    public Photo: string;


    constructor() {
    }
}
