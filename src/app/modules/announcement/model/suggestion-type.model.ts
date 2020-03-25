// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class SuggestionType extends ModelBase {
    public SuggestionTypeId = 0;
    public SuggestionTypeName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SuggestionTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.SuggestionTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
