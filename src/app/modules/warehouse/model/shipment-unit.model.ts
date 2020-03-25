// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ShipmentUnit extends ModelBase {
    public ShipmentUnitId = 0;
    public UnitName: string;
    public PackageQuantity: number;
    public Comment?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ShipmentUnitId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ShipmentUnitId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
