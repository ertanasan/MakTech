// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class StockGroupName extends ModelBase {
    public StockGroupNameId = 0;
    public StockGroupName: string;
    public UsageType?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StockGroupNameId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StockGroupNameId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
