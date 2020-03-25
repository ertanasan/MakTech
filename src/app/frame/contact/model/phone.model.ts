// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Phone extends ModelBase {
    public PhoneId = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Organization = 0;
    public Contact = 0;
    public SubContactType = 0;
    public PhoneNo: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.PhoneId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.PhoneId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
    /*Section="ClassFooter"*/
}
