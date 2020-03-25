// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Notification extends ModelBase {
    public NotificationId: number;
    public Event: number;
    public Organization: number;
    public Deleted: boolean;
    public CreationDate: Date;
    public UpdateDate?: Date;
    public Creator: number;
    public Updater?: number;
    public TransactionChannel: number;
    public TransactionBranch: number;
    public TransactionScreen: number;
    public Source: string;
    public Status: string;
    public Priority: number;
    public Provider: number;
    public ProcessingDate?: Date;
    public Template: number;
    public ProcessInstance?: number;
    public ActivityInstance?: number;
    public FromRecipient: string;
    public Subject: string;
    public Body: string;



    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.NotificationId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.NotificationId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
