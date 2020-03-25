// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Suggestion extends ModelBase {
    public SuggestionId = 0;
    public Event = 1050;
    public Organization = 1;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public BranchName: string;
    public SuggestionText: string;
    public ProcessInstance?: number;
    public Status: number = 1;
    public Type?: number;
    public InnovativenessRating?: number;
    public FeasibilityRating?: number;
    public AddedValueRating?: number;
    public PreviousActionComment?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SuggestionId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.SuggestionId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
}

export class SuggestionHistory {
    public CreateDate = new Date();
    public StartTime = new Date();
    public FinishTime = new Date();
    public Performer = 0;
    public ActionStatusCode = 0;
    public ProcessStatusCode = 0;
    public Choice: string;
    public ActionComment: string;
    //#endregion Customized

    /*Section="ClassFooter"*/
}
