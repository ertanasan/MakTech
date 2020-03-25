// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class NotificationStore extends ModelBase {
    public Notification = 0;
    public Store = 0;
    public CreateDate = new Date();
    public CreateUser = 0;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public ProcessInstance?: number;
    public StoreName: string;
    public StoreList: Number[];

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return new RelationId(this.Notification, this.Store);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
