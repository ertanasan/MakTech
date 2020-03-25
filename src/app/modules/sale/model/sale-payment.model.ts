// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class SalePayment extends ModelBase {
    public SalePaymentId = 0;
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
    public SaleID: number;
    public TransactionID: string;
    public TransactionDate: Date;
    public Store: number;
    public PaymentType: string;
    public PaidAmount: number;
    public RefundAmount: number;
    public PosBankType?: number;
    public PosTrxType?: number;
    public CreditCardNo?: string;
    public IsDebitCard?: boolean;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SalePaymentId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.SalePaymentId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
        
    /*Section="ClassFooter"*/
}
