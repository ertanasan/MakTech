// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class StoreProperty extends ModelBase {
    public Store: number;
    public PropertyType: number;
    public PropertyValue: string;
    public PropertyId = 0;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.PropertyId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.PropertyId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
