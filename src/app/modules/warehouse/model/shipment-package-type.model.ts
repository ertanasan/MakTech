// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ShipmentPackageType extends ModelBase {
    public ShipmentPackageTypeId = 0;
    public PackageTypeName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ShipmentPackageTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ShipmentPackageTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
