// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class StoreAccountType extends ModelBase {
    public StoreAccountTypeId = 0;
    public AccountTypeName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StoreAccountTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StoreAccountTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
