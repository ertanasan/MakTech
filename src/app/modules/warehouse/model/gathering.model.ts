// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Gathering extends ModelBase {
    public GatheringId = 0;
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
    public StoreOrder: number;
    public GatheringUser?: number;
    public GatheringStartTime?: Date;
    public GatheringEndTime?: Date;
    public GatheringStatus: number;
    public GatheringType: number;
    public StoreName: string;
    public Priority?: number;
    public OrderDate?: Date;
    public ShipmentDate?: Date;
    public StoreOrderName?: string;
    public GatheringTypeName?: string;
    public GatheringUserName?: string;
    public OrderTotalKg?: number;
    public ProductCount: number;
    public PackageCount: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.GatheringId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.GatheringId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
}

export class GatheringStats {
    public WaitingLightCount = 0;
    public WaitingHeavyCount = 0;
    public ProcessingLightCount = 0;
    public ProcessingHeavyCount = 0;
    public OnHoldLightCount = 0;
    public OnHoldHeavyCount = 0;
    public WaitingForControlLightCount = 0;
    public WaitingForControlHeavyCount = 0;
    public ControllingLightCount = 0;
    public ControllingHeavyCount = 0;
    public OnHoldControlLightCount = 0;
    public OnHoldControlHeavyCount = 0;

    constructor() {
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
