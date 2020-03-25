// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ConsignmentGoodPurchase extends ModelBase {
    public ConsignmentGoodPurchaseId = 0;
    public Event = 1052;
    public Organization = 1;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public Store: number;
    public Product: number;
    public Supplier: number;
    public Quantity: number;
    public UnitName: string;
    public TransactionType: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ConsignmentGoodPurchaseId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ConsignmentGoodPurchaseId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
