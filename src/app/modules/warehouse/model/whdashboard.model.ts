import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

export class WarehouseDashboard extends ModelBase {

    OrderList: OrderDBList[];
    GatheringList: GatheringDBList[];
    ControlList: ControlDBList[];

    constructor() {
        super();
    }

    setId(id: number) {
        
    }

    getId(): number | RelationId {
        return 1
    }
}


export class OrderDBList {
    StoreOrderId: number;
    Status: number;
    Store: number;
    OrderDate: Date;
    ShipmentDate: Date;
    OldOrderFlag: boolean;
    OrderWeight: number;
    HeavyOrderWeight: number;
    LightOrderWeight: number;
    HeavyGatheredWeight: number;
    LightGatheredWeight: number;
    WaitingHeavyOrderCount: number;
    WaitingLightOrderCount: number;
    WaitingHeavyControlPalletCount: number;
    WaitingLightControlPalletCount: number;
    OrderPrice: number;
}

export class GatheringDBList {
    GatheringType: number;
    GatheringUserName: string;
    GatheredWeight: number;
    GatheredPalletCount: number;
    OrderCount: number;
    GatheredPackage: number;
}

export class ControlDBList {
    GatheringType: number;
    ControlUser: number;
    ControlUserName: string;
    ControlPalletCount: number;
    ControlledPalletCount: number;
}