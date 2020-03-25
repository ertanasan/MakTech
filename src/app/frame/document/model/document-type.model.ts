// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class DocumentType extends ModelBase {
    public DocumentTypeId = 0;
    public Name: string;
    public Extention?: string;
    public Description?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.DocumentTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.DocumentTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
