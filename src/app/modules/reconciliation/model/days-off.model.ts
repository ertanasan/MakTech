// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class DaysOff extends ModelBase {
    public DaysOffId = 0;
    public Store: number;
    public OffDay: Date;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.DaysOffId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.DaysOffId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
