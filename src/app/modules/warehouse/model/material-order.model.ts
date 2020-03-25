// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class MaterialOrder extends ModelBase {
    public MaterialOrderId = 0;
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
    public OrderName: string;
    public OrderDate: Date;
    public OrderStatusCode: number;
    public Store: number;
    public ProcessInstanceNumber?: number;
    public MikroStatusCode?: number;
    public MikroReference?: string;
    public MikroTime?: Date;
    public MikroUser?: number;
    public Material: number;
    public MaterialInfo?: number;
    public OrderQuantity: number;
    public RevisedQuantity: number;
    public ShippedQuantity: number;
    public IntakeQuantity: number;
    public Note: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.MaterialOrderId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.MaterialOrderId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}

export class MaterialOrderUpdateList {
    public OrderStatusCode: number;
    public MaterialOrderIdList: number[];
}