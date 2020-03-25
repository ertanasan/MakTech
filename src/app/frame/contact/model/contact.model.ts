import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

import { Phone } from './phone.model';
import { Address } from './address.model';
import { Web } from './web.model';

/*Section="ClassHeader"*/
export class Contact extends ModelBase {
    public ContactId = 0;
    public Deleted: boolean;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Organization = 0;
    public MainContactType = 0;
    public SubContactTypeName: string;
    public Description: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ContactId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ContactId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    // tslint:disable-next-line:member-ordering
    public AddressContact: Address;
    // tslint:disable-next-line:member-ordering
    public PhoneContact: Phone;
    // tslint:disable-next-line:member-ordering
    public WebContact: Web;
    // tslint:disable-next-line:member-ordering
    public ContactObject: Contact;

    //#endregion Customized
    /*Section="ClassFooter"*/
}
