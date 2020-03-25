// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ShipmentSchedule extends ModelBase {
    public ShipmentScheduleId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public ShipmentScheduleName: string;
    public Store: number;
    public ScheduleDetail: string;
    public Comment?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ShipmentScheduleId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ShipmentScheduleId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
