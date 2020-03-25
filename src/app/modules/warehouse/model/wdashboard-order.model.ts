import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

export class WDashboardOrder extends ModelBase {
    public WidgetData: WDWidgetData;
    public GatheringDifferences: WDGatheringDifference[];
    public OrderTrend: OrderTrend;

    constructor() {
        super();
    }

    setId(id: number) {
    }

    getId(): number | RelationId {
        return 1;
    }
}

export class WDWidgetData extends ModelBase {
    public HeavyOrderAmount: number;
    public LightOrderAmount: number;
    public HeavyGatheredAmount: number;
    public LightGatheredAmount: number;
    public HeavyOrderPackage: number;
    public LightOrderPackage: number;
    public HeavyGatheredPackage: number;
    public LightGatheredPackage: number;
    public NonGatheredHeavyProduct: number;
    public HeavyProductCount: number;
    public NonGatheredLightProduct: number;
    public LightProductCount: number;

    constructor() {
        super();
    }

    setId(id: number) {
    }

    getId(): number | RelationId {
        return 1;
    }
}

export class WDGatheringDifference extends ModelBase {
    public ProductCode: string;
    public ProductName: string;
    public CurrentStock: number;
    public NotGatheredStoreCount: number;
    public GatheredStoreCount: number;
    public NotGatheredStoreRate: number;
    public NotGatheredQuantity: number;
    public GatheredQuantity: number;

    constructor() {
        super();
    }

    setId(id: number) {
    }

    getId(): number | RelationId {
        return 1;
    }
}

export class OrderTrend extends ModelBase {
    public GatherDate: Date;
    public OrderQuantity: number;
    public ShippedQuantity: number;

    constructor() {
        super();
    }

    setId(id: number) {
    }

    getId(): number | RelationId {
        return 1;
    }
}
