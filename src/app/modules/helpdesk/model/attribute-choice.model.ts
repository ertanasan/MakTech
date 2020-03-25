// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class AttributeChoice extends ModelBase {
    public AttributeChoiceId = 0;
    public Attribute: number;
    public ChoiceName: string;
    public DisplayOrder?: number;
    public PriorityPoint?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.AttributeChoiceId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.AttributeChoiceId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
