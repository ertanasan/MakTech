// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class SaleCustomer extends ModelBase {
    public SaleCustomerId = 0;
    public Event = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public Sale: number;
    public EInvoiceFlag: boolean;
    public CustomerName: string;
    public Address?: string;
    public TaxCenterName?: string;
    public TaxIdentityNo: string;
    public Email?: string;
    public PhoneNumber?: string;
    public FiscalSerial?: string;
    public EInvoiceZetNumber?: number;
    public EInvoiceReceiptNumber?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SaleCustomerId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.SaleCustomerId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
