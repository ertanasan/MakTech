// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class ActivityInstance extends ModelBase {
    public TransactionBranch: number;
    public FinishTime?: Date;
    public StartTime?: Date;
    public Status: number;
    public ActivityNo: number;
    public ActivityType: number;
    public ProcessInstance: number;
    public Name: string;
    public TransactionScreen: number;
    public LastActivityCheck: string;
    public TransactionChannel: number;
    public Updater?: number;
    public Creator: number;
    public UpdateDate?: Date;
    public CreationDate: Date;
    public Deleted: boolean;
    public Organization: number;
    public Event: number;
    public ActivityInstanceId: number;


    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ActivityInstanceId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.ActivityInstanceId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
