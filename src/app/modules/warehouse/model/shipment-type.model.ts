// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ShipmentType extends ModelBase {
    public ShipmentTypeId = 0;
    public ShipmentTypeName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ShipmentTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ShipmentTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
