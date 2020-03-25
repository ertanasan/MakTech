// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class CardDistribution extends ModelBase {
    public CardDistributionId = 0;
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
    public CardGroupCode: number;
    public CardZetAmount: number;
    public StoreRec: number;
    public CardGroupName?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.CardDistributionId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.CardDistributionId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
