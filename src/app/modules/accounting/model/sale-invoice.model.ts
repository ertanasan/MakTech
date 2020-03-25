// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class SaleInvoice extends ModelBase {
    public SaleInvoiceId = 0;
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
    public EInvoiceFlag: boolean;
    public CustomerIdNumber: number;
    public Title: string;
    public Email: string;
    public Sale: number;
    public EInvoiceClient?: number;
    public Address?: string;
    public StatusCode: number;
    public MikroFlag: boolean;
    public MikroTransferTime?: Date;
    public SaleDate?: Date;
    public SaleRef?: string;
    public SaleAmount?: number;
    public SaleStore?: number;
    public ProcessInstance?: number;
    public PhoneNumber?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SaleInvoiceId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.SaleInvoiceId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
