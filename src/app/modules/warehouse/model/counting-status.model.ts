// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class CountingStatus extends ModelBase {
    public CountingStatusId = 0;
    public CountingStatusName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.CountingStatusId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.CountingStatusId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
