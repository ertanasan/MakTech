// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Action extends ModelBase {
    public ActivityInstance: number;
    public DelegateFrom?: number;
    public Description: string;
    public Performer?: number;
    public AllowBulk: boolean;
    public FinishTime?: Date;
    public StartTime?: Date;
    public Choice: string;
    public Choices: string;
    public User?: number;
    public Department?: number;
    public Branch?: number;
    public Group: number;
    public TargetScope: number;
    public ScreenReference: string;
    public OwningExpirationTime?: Date;
    public ProcessInstance: number;
    public Priority: number;
    public Status: number;
    public TransactionScreen: number;
    public TransactionBranch: number;
    public TransactionChannel: number;
    public Updater?: number;
    public Creator: number;
    public UpdateDate?: Date;
    public CreationDate: Date;
    public Deleted: boolean;
    public Organization: number;
    public Event: number;
    public ActionId: number;
    public Owner?: number;


    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ActionId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.ActionId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
