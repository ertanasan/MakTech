// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class RentPaymentPlan extends ModelBase {
    public RentPaymentPlanId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public RentPeriod: number;
    public PaymentOrder: number;
    public DueDate: Date;
    public PaymentAmount: number;
    public Currency = 'TRY';
    public AdditionalPaymentAmount?: number;
    public AdditionalPaymentCurrency = 'TRY';
    public Comment?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.RentPaymentPlanId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.RentPaymentPlanId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
