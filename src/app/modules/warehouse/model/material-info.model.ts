// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class MaterialInfo extends ModelBase {
    public MaterialInfoId = 0;
    public Material: number;
    public ShortName: string;
    public InfoName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.MaterialInfoId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.MaterialInfoId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
