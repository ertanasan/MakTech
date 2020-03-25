// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class OverStoreTaskType extends ModelBase {
    public OverStoreTaskTypeId = 0;
    public TaskType: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.OverStoreTaskTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.OverStoreTaskTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
