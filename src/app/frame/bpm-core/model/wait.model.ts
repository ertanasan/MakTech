// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Wait extends ModelBase {
    public WaitId: number;
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
    public Type: number;
    public ProcessInstance: number;
    public ActivityInstance: number;
    public Status: number;
    public WakeTime: Date;
    public Duration: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.WaitId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.WaitId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
