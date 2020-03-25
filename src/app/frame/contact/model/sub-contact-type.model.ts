// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class SubContactType extends ModelBase {
    public SubContactTypeId = 0;
    public Name: string;
    public MainContact: number;
    public Description?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SubContactTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.SubContactTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
    /*Section="ClassFooter"*/
}
