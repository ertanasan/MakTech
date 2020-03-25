// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Landlord extends ModelBase {
    public LandlordId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public LandlordName: string;
    public LandlordType: number;
    public LandlordAddress: string;
    public ContactInfo?: string;
    public NationalId?: string;
    public TaxpayerId?: string;
    public TaxOffice?: string;
    public LegalRepresentative?: number;
    public AccountingCode?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.LandlordId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.LandlordId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
}
export class LandlordMikro extends ModelBase {
    public LandLordGuId: string;
    public Code: string;
    public Code2: string;
    public Name1: string;
    public Name2: string;
    public Currency: string;
    public LandlordType: number;
    public LandlordAddress: string;
    public ContactInfo: string;
    public NationalId: string;
    public TaxpayerId: string;
    public TaxOffice: string;
    public Iban: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) { }

    /*Section="Method-getId"*/
    getId(): number | RelationId { return 0; }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
