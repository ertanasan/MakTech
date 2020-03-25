import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import { WDWidgetData } from './wdashboard-order.model';

export class WDashboardGathering extends ModelBase {
    WidgetData: WDGatherPerformanceSummary;
    GatheringTrend: WDGatheringTrend[];
    GatheringTrendByUserList: WDGatheringTrendByUser[];

    constructor() {
        super();
    }

    setId(id: number) {
    }

    getId(): number | RelationId {
        return 1;
    }
}

export class WDGatherPerformanceSummary extends ModelBase {
    public TodayQty: number;
    public TheDayLastWeekUntilNowQty: number;
    public YesterdayQty: number;
    public DailyAvgQty: number;
    public TodaySecondsPerKg: number;
    public AvgSecondsPerKg: number;
    public TodayErrorCnt: number;
    public AvgErrorCnt: number;

    constructor() {
        super();
    }

    setId(id: number) {
    }

    getId(): number | RelationId {
        return 1;
    }
}

export class WDGatheringTrend extends ModelBase {
    public GatherUserId: number;
    public GatherUserName: string;
    public GatherDate: Date;
    public GatherQuantity: number;
    public ControlErrorCount: number;
    public ControlDiffPackage: number;
    public GatherPackage: number;
    public ErrorRate: number;

    constructor() {
        super();
    }

    setId(id: number) {
    }

    getId(): number | RelationId {
        return 1;
    }
}

export class WDGatheringTrendByUser extends ModelBase {
    public GatherUserId: number;
    public GatherUserName: string;
    public GatheringTrendList: WDGatheringTrend[];

    constructor() {
        super();
    }

    setId(id: number) {
    }

    getId(): number | RelationId {
        return 1;
    }
}
