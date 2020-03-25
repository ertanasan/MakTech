// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class TransactionType extends ModelBase {
    public TransactionTypeId = 0;
    public TransactionName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.TransactionTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.TransactionTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
        
    /*Section="ClassFooter"*/
}
