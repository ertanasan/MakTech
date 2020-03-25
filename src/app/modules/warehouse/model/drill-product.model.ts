// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class DrillProduct extends ModelBase {
    public DrillProductId = 0;
    public CountingDate: Date;
    public Product: number;
    public Store: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.DrillProductId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.DrillProductId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
