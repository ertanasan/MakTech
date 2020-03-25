// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class PosTrxType extends ModelBase {
    public PosTrxTypeId = 0;
    public TrxType: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.PosTrxTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.PosTrxTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
        
    /*Section="ClassFooter"*/
}
