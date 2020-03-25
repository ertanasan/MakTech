// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class PropertyType extends ModelBase {
    public PropertyTypeId = 0;
    public Name: string;
    public Description?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.PropertyTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.PropertyTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
        
    /*Section="ClassFooter"*/
}
