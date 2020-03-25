// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import {Web} from '@contact/model/web.model';
import {Address} from '@contact/model/address.model';
import {Phone} from '@contact/model/phone.model';
import {Contact} from '@contact/model/contact.model';

/*Section="ClassHeader"*/
export class FirmContact extends ModelBase {
    public Firm = 0;
    public Contact = 0;
    public CreateDate = new Date();
    public CreateUser = 0;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public IsDefault = false;
    public IsActive = false;
    public IsPreferred = false;
    public FirmName: string;
    public ContactContactId: number;
    public ContactObject = new Contact();

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return new RelationId(this.Firm, this.Contact);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
