// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class QuestionChoice extends ModelBase {
    public QuestionChoiceId = 0;
    public Question: number;
    public ChoiceText: string;
    public RightAnswer: boolean;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.QuestionChoiceId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.QuestionChoiceId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
