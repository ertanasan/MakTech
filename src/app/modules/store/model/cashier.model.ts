// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Cashier extends ModelBase {
    public CashierId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Store: number;
    public CashierName: string;
    public CashierTemplateNumber: number;
    public CashierTitleNumber: number;
    public Password: number;
    public CashierFlag: boolean;
    public IsActive: boolean;
    public Salesman: boolean;
    public WorkingType: number;
    public Note?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.CashierId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.CashierId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
