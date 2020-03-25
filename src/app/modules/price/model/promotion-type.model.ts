// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class PromotionType extends ModelBase {
    public PromotionTypeId = 0;
    public PromotionName: string;
    public Description?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.PromotionTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.PromotionTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
