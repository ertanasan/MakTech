// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class StockTaking extends ModelBase {
    public StockTakingId = 0;
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
    public Store: number;
    public CountingDate: Date;
    public Product: number;
    public CountingValue: number;
    public Zone: number;
    public StockTakingSchedule: number;
    public ProductCode?: string;
    public ScaleCode?: string;
    public ProductName?: string;
    public Category?: string;
    public Unit?: string;
    public InitialCountingValue: number;
    public UnitPrice?: number;
    public CurrentStock?: number;
    public StockRed?: boolean;
    public CountingPrice?: number;
    public Zone1?: number;
    public Zone2?: number;
    public Zone3?: number;
    public ZoneTotal?: number;
    public StockTakingId1?: number;
    public StockTakingId2?: number;
    public StockTakingId3?: number;
    public MainWarehouseStock?: number;
    public ProductionWarehouseStock?: number;
    public RefundWarehouseStock?: number;
    public GatheredStock?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StockTakingId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StockTakingId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    //#endregion Customized

    /*Section="ClassFooter"*/
}

export class ScannedItem {
    public ProductName: string;
    public ScannedValue: number;
    public FinalValue: number;
    public ScanTime: Date;
}
