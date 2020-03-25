// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class ProductProperty extends ModelBase {
    public ProductPropertyId = 0;
    public PropertyType: number;
    public Product: number;
    public Value: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ProductPropertyId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.ProductPropertyId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
