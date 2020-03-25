// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class CashierTemplate extends ModelBase {
    public CashierTemplateId = 0;
    public CashierTemplateName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.CashierTemplateId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.CashierTemplateId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
