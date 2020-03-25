// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class CashDistribution extends ModelBase {
    public CashDistributionId = 0;
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
    public StoreReconciliation: number;
    public Banknote: number;
    public Quantity: number;
    public GroupCode: number;
    public Amount?: number;
    public BanknoteAmount?: number;
    public CoinFlag?: boolean;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.CashDistributionId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.CashDistributionId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
