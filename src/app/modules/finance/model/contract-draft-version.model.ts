// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import {DocumentHandle} from '@otmodel/document-handle.model';

/*Section="ClassHeader"*/
export class ContractDraftVersion extends ModelBase {
    public ContractDraftVersionId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public DocumentId = 0;
    public ChangeDetails?: string;
    public DraftDocument = new DocumentHandle();

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ContractDraftVersionId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ContractDraftVersionId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
