// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class BarcodeTypeInt extends ModelBase {
    public BarcodeTypeID: number;
    public BarcodeType: string;
    public Comment: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.BarcodeTypeID = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.BarcodeTypeID;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
