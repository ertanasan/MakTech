// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class StorePropertyType extends ModelBase {
    public StorePropertyId = 0;
    public PropertyName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StorePropertyId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StorePropertyId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
