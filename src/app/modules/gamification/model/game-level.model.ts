// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class GameLevel extends ModelBase {
    public GameLevelId = 0;
    public Game: number;
    public LevelName: string;
    public QuestionCount: number;
    public MinDifficultyLevel: number;
    public MaxDifficultyLevel: number;
    public Duration: number;
    public LevelErrorTolerance?: number;
    public PointofRightAnswer: number;
    public LevelCode: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.GameLevelId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.GameLevelId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
