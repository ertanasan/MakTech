// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ReturnReason extends ModelBase {
    public ReturnReasonId = 0;
    public ReasonName: string;
    public Parent?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ReturnReasonId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ReturnReasonId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
