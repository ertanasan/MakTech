// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class EngineException extends ModelBase {
    public Updater?: number;
    public InnerException: string;
    public StackTrace: string;
    public Message: string;
    public ErrorCode: number;
    public TransactionScreen: number;
    public TransactionBranch: number;
    public TransactionChannel: number;
    public ProcessInstance?: number;
    public Creator: number;
    public UpdateDate?: Date;
    public CreationDate: Date;
    public Deleted: boolean;
    public Organization: number;
    public Event: number;
    public EngineExceptionId: number;
    public ActivityInstance?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.EngineExceptionId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.EngineExceptionId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
