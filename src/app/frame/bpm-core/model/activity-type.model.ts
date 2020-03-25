// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class ActivityType extends ModelBase {
    public ActivityTypeId: number;
    public Name: string;
    public Description: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ActivityTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.ActivityTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
