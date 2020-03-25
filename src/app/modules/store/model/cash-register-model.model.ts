// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class CashRegisterModel extends ModelBase {
    public CashRegisterModelId = 0;
    public Brand: number;
    public Name: string;
    public Description?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.CashRegisterModelId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.CashRegisterModelId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
