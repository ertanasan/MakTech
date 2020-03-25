// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class PublicParameter extends ModelBase {
    public PublicParameterId = 0;
    public Name: string;
    public Value?: string;
    public Description?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.PublicParameterId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.PublicParameterId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
