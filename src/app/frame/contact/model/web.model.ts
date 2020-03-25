import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Web extends ModelBase {
    public WebId = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Organization = 0;
    public Contact = 0;
    public SubContactType = 0;
    public Address: string;
    public Description: string;


    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.WebId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.WebId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
    /*Section="ClassFooter"*/
}
