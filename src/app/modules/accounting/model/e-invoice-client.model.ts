// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class EInvoiceClient extends ModelBase {
    public EInvoiceClientId = 0;
    public Identifier: number;
    public Alias: string;
    public Title: string;
    public Type: string;
    public FirstCreateTime?: Date;
    public AliasCreateTime?: Date;
    public Email: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.EInvoiceClientId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.EInvoiceClientId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
