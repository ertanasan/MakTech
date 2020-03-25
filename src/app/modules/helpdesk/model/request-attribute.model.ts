// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class RequestAttribute extends ModelBase {
    public RequestAttributeId = 0;
    public AttributeName: string;
    public RequestGroup?: number;
    public RequestDefinition?: number;
    public AttributeType: number;
    public EditableFlag?: boolean;
    public RequiredFlag?: boolean;
    public DisplayOrder?: number;
    public isGroup?: boolean;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.RequestAttributeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.RequestAttributeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
