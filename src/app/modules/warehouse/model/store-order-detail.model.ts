// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class StoreOrderDetail extends ModelBase {
    public StoreOrderDetailId = 0;
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
    public Product: number;
    public OrderQuantity: number;
    public RevisedQuantity?: number;
    public ShippedQuantity?: number;
    public IntakeQuantity?: number;
    public SuggestionQuantity?: number;
    public OrderUnitQuantity: number;
    public StoreOrder: number;
    public ProductCode?: string;
    public ProductName?: string;
    public SubGroupName?: string;
    public Category?: string;
    public ScaleCode?: string;
    public PackageQuantity = 0;
    public PackageType?: string;
    public Unit?: string;
    public LoadOrder?: string;
    public TotalQuantity?: number;
    public UnitQuantityText?: string;
    public PriceAmount: number;
    public OnWayQuantity: number;
    public TotalAmount: number;
    public OldOrderQuantity: number;
    public OldRevisedQuantity: number;
    public OldShippedQuantity: number;
    public OldIntakeQuantity: number;
    public WeightAmount: number;
    public ClosetoOrder?: boolean;
    public SaleAverage?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StoreOrderDetailId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StoreOrderDetailId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}


/*Section="ClassHeader"*/
export class WarehouseProductUnit extends ModelBase {
    public ProductId = 0;
    public ProductCode: string;
    public ScaleCode: string;
    public Category: string;
    public SubGroup: string;
    public ProductName: string;
    public PackageQuantity: number;
    public PackageType: string;
    public Unit: string;
    public LoadLocation: string;
    public SearchString: string;
    public OnWayQuantity: number;
    public PriceAmount: number;


    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ProductId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ProductId;
    }


}
