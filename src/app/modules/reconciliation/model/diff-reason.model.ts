// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class DiffReason extends ModelBase {
    public DiffReasonId = 0;
    public ReasonName: string;
    public ShortFlag?: boolean;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.DiffReasonId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.DiffReasonId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
