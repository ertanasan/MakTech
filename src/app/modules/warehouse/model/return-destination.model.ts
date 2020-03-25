// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ReturnDestination extends ModelBase {
    public ReturnDestinationId = 0;
    public DestinationName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ReturnDestinationId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ReturnDestinationId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
