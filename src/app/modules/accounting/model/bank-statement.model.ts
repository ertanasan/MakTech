// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class BankStatement extends ModelBase {
    public BankStatementId = 0;
    public Event = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public Bank: number;
    public Date: Date;
    public Description: string;
    public TransactionAmount: number;
    public Balance: number;
    public Channel: string;
    public Info1?: string;
    public Info2?: string;
    public Info3?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.BankStatementId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.BankStatementId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
