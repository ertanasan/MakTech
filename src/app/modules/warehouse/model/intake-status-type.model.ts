// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class IntakeStatusType extends ModelBase {
    public IntakeStatusTypeId = 0;
    public IntakeStatusTypeName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.IntakeStatusTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.IntakeStatusTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
