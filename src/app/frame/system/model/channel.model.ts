// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Channel extends ModelBase {
    public ChannelId = 0;
    public Name: string;
    public IsActive: boolean;
    public Description: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ChannelId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ChannelId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
