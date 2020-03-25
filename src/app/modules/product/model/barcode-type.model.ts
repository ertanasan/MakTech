// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class BarcodeType extends ModelBase {
    public BarcodeTypeId = 0;
    public BarcodeTypeName: string;
    public Comment: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.BarcodeTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.BarcodeTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
