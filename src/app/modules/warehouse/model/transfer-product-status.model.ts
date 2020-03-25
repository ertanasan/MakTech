// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class TransferProductStatus extends ModelBase {
    public TransferProductStatusId = 0;
    public ProductStatusName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.TransferProductStatusId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.TransferProductStatusId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
