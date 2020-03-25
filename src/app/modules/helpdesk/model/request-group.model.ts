// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class RequestGroup extends ModelBase {
    public RequestGroupId = 0;
    public RequestGroupName: string;
    public DisplayOrder?: number;
    public ActiveFlag?: boolean;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.RequestGroupId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.RequestGroupId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
