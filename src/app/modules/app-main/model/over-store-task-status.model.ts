// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class OverStoreTaskStatus extends ModelBase {
    public OverStoreTaskStatusId = 0;
    public Status: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.OverStoreTaskStatusId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.OverStoreTaskStatusId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
