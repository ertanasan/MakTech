// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import { FolderHandle } from '@otmodel/folder-handle.model';

/*Section="ClassHeader"*/
export class Notification extends ModelBase {
    public NotificationId = 0;
    public Event = 1051;
    public Organization = 1;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public NotificationText: string;
    public NotificationType: number;
    public NotificationStatus: number;
    public UserCount?: number;               // HAVE MANY USERS THE NOTIFICATION WILL BE PUBLISHED TO
    public ReadCount?: number;               // HAVE MANY USERS HAVE READ THE NOTIFICATIONs
    public Folder?: number;

    public FolderHandle = new FolderHandle();

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.NotificationId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.NotificationId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
