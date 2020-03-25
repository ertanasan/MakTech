// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Item extends ModelBase {
    public ItemId: number;
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
    public WorkQueue: number;
    public Action: number;
    public Status: number;
    public Performer?: number;
    public AssignTime?: Date;
    public StartTime?: Date;
    public FinishTime?: Date;
    public Priority: number;
    public CalculatedPriority: number;
    public ProcessInstance: number;
    public ActivityInstance: number;
    public Originator: number;


    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ItemId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.ItemId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
