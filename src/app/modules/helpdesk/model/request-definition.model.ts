// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class RequestDefinition extends ModelBase {
    public RequestDefinitionId = 0;
    public RequestDefinitionName: string;
    public RequestGroup: number;
    public Process: number;
    public MicroCode?: string;
    public DisplayOrder?: number;
    public ActiveFlag?: boolean;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.RequestDefinitionId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.RequestDefinitionId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
