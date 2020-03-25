// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class GamePlay extends ModelBase {
    public GamePlayId = 0;
    public Event = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public Game: number;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public Player: number;
    public StartTime: Date;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public EndTime?: Date;
    public LastLevel?: number;
    public QuestionCount?: number;
    public Score: number;
    public DeviceInfo?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.GamePlayId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.GamePlayId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
