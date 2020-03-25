// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class GamePlayAnswer extends ModelBase {
    public GamePlayAnswerId = 0;
    public Event = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public Play: number;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public Question: number;
    public AnswerChoice: number;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public ResultFlag: boolean;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.GamePlayAnswerId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.GamePlayAnswerId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
