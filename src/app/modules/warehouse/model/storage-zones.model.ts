// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class StorageZones extends ModelBase {
    public StorageZonesId = 0;
    public Location: string;
    public ZoneName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StorageZonesId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StorageZonesId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
