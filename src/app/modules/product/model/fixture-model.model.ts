// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class FixtureModel extends ModelBase {
    public FixtureModelId = 0;
    public Brand: number;
    public ModelName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.FixtureModelId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.FixtureModelId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
