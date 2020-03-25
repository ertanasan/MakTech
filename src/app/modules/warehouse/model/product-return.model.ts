// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import { ProductReturnReason } from './product-return-reason.model';

/*Section="ClassHeader"*/
export class ProductReturn extends ModelBase {
    public ProductReturnId = 0;
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
    public ReturnDate: Date;
    public WaybillDate?: Date;
    public Product: number;
    public Supplier?: string;
    public ManufacturingDate?: Date;
    public ExpireDate?: Date;
    public ReturnQuantity: number;
    public PackageType: number;
    public ReturnReasonText?: string;
    public ReturnDestination?: number;
    public StatusCode: number;
    public ProcessInstance?: number;
    public Store: number;
    public ReturnReasons?: string;
    public StatusText?: string;
    public IntakeAmount?: number;
    public IsCustomerReturn?: boolean;
    public ReusableFlag?: boolean;
    public ReturnReason?: ProductReturnReason[];
    public SaleDetailId?: number;
    public SaleDetailText?: string;
    public WaybillText?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ProductReturnId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ProductReturnId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
}

export class ProductReturnHistory {
    public CreateDate = new Date();
    public StartTime = new Date();
    public FinishTime = new Date();
    public Performer = 0;
    public ActionStatusCode = 0;
    public ProcessStatusCode = 0;
    public Choice: string;
    public ActionComment: string;
    //#endregion Customized

    /*Section="ClassFooter"*/
}
