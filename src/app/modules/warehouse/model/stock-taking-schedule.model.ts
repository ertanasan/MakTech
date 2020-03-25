// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class StockTakingSchedule extends ModelBase {
    public StockTakingScheduleId = 0;
    public Event = 1;
    public Organization = 1;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public ScheduleName: string;
    public Store: number;
    public CountingType: number;
    public PlannedDate: Date;
    public ActualDate?: Date;
    public CountingStatus: number;
    public ScheduleFullName: string;
    public TakingUser: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StockTakingScheduleId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StockTakingScheduleId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
