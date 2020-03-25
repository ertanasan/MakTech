// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ProductStockGroup extends ModelBase {
    public Product: number;
    public StockGroup: number;
    public StockGroupId = 0;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StockGroupId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StockGroupId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
