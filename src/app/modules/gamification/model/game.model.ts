// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

export class GameScore extends ModelBase {

    public PlayerId: number;
    public BranchName: string;
    public PlayerName: string;
    public DayGroup: string;
    public MaxScore: number;
    public MaxLevel: number;
    public QuestionCount: number;
    public GameCount: number;
    public AvgScore: number;
    public RowNumber: number;

    setId(id: number) {
    }

    getId(): number | RelationId {
        return 1;
    }
}

/*Section="ClassHeader"*/
export class Game extends ModelBase {
    public GameId = 0;
    public GameName: string;
    public ErrorTolerance?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.GameId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.GameId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
