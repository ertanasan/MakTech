// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class OverStoreTaskHistory extends ModelBase {
    public OverStoreTaskHistoryId = 0;
    public Event = 1058
    public Organization = 1;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public OverStoreTask: number;
    public HistoryTime: Date;
    public Status: number;
    public ChangeDetail?: string;
    public ResponsibleType: number;
    public ResponsibleUser?: number;
    public ResponsibleGroup?: number;
    public ResponsibleBranch?: number;
    public ForwardableFlag = true;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.OverStoreTaskHistoryId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.OverStoreTaskHistoryId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
