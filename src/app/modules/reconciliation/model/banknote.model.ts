// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Banknote extends ModelBase {
    public BanknoteId = 0;
    public BanknoteAmount: number;
    public CoinFlag?: boolean;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.BanknoteId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.BanknoteId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
