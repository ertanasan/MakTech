// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import { QuestionChoice } from './question-choice.model';

/*Section="ClassHeader"*/
export class GameQuestion extends ModelBase {
    public GameQuestionId = 0;
    public QuestionText: string;
    public DifficultyLevel: number;
    public Choices: QuestionChoice[];

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.GameQuestionId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.GameQuestionId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
