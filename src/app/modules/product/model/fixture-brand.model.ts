// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class FixtureBrand extends ModelBase {
    public FixtureBrandId = 0;
    public Fixture: number;
    public BrandName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.FixtureBrandId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.FixtureBrandId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
