// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class IntakeStatus extends ModelBase {
    public IntakeStatusId = 0;
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
    public StoreOrderDetail: number;
    public IntakeStatusType: number;
    public Description?: string;
    public IsTransferred: boolean;
    public MikroTransferTime?: Date;
    public QuantityDifference: number;
    public DifferenceType: string;
    public StoreName?: string;
    public ProductName?: string;
    public UnitName?: string;
    public OrderDate?: Date;
    public MikroShipmentDate?: Date;
    public IntakeDate?: Date;
    public ShippedQuantity?: number;
    public IntakeQuantity?: number;
    public StoreOrder: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.IntakeStatusId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.IntakeStatusId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
