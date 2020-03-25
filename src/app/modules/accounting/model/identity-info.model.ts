// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class IdentityInfo extends ModelBase {
    public IdentityInfoId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public IdentityNo: string;
    public IdentityName: string;
    public TaxCenterCode: string;
    public TaxCenterName: string;
    public ActiveStatus?: string;
    public CompanyType?: string;
    public FatherName?: string;
    public IdentityType?: string;
    public ProfessionCode?: string;
    public Profession?: string;
    public Address?: string;
    public Email?: string;
    public PhoneNumber?: string;
    public EInvoiceFlag?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.IdentityInfoId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.IdentityInfoId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
