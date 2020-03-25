// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Material extends ModelBase {
    public MaterialId = 0;
    public MaterialName: string;
    public MikroCode?: string;
    public UnitCode: number;
    public Category?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.MaterialId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.MaterialId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
