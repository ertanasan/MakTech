// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class FakeOrder extends ModelBase {
    public FakeOrderId = 0;
    public Event = 1054;
    public Organization = 1;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public OrderDate: Date;
    public Store: number;
    public Product: number;
    public SentAmount: number;
    public StoreList: number[];

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.FakeOrderId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.FakeOrderId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
