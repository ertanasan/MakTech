// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ProductCampaign extends ModelBase {
    public ProductCampaignId = 0;
    public Name: string;
    public ImagePath?: string;
    public Active: boolean;
    public Comment?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ProductCampaignId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ProductCampaignId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
