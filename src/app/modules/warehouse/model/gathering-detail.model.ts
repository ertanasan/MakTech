// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class GatheringDetail extends ModelBase {
    public GatheringDetailId = 0;
    public Event = 1047;
    public Organization = 1;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public StoreOrderDetail: number;
    public GatheringTime?: Date;
    public Gathering: number;
    public GatheredQuantity?: number;
    public PalletNo = 1;
    public ControlQuantity?: number;
    public ControlTime?: Date;
    public ProductName: string;
    public ProductCode: string;
    public OrderQuantity: number;
    public PackageUnit: number;
    public Proceed = false;
    public UnitName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.GatheringDetailId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.GatheringDetailId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}

export class PostList {
    public GatheringId: number;
    public PalletNo: number;
    public ProductId: number;
}