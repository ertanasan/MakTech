// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import {FolderHandle} from '@otmodel/folder-handle.model';

/*Section="ClassHeader"*/
export class OverStoreTask extends ModelBase {
    public OverStoreTaskId = 0;
    public Event = 1058;
    public Organization = 1;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public Status = 1;
    public Type: number;
    public Content?: string;
    public Deadline?: Date;
    public DeadlineFlag = false;
    public ResponsibleType: number;
    public ResponsibleUser?: number;
    public ResponsibleGroup?: number;
    public ResponsibleBranch?: number;
    public ProcessInstance?: number;
    public ForwardableFlag = true;
    public PreviousActionComment?: string;
    public Folder?: number;
    public FolderHandle = new FolderHandle();

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.OverStoreTaskId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.OverStoreTaskId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
