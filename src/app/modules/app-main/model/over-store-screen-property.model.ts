// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class OverStoreScreenProperty extends ModelBase {
    public OverStoreScreenPropertyId = 0;
    public Screen: number;
    public PropertyName: string;
    public PropertyValue: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.OverStoreScreenPropertyId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.OverStoreScreenPropertyId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
