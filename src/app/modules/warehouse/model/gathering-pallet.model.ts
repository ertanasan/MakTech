// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class GatheringPallet extends ModelBase {
    public GatheringPalletId = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public CreateUser = 0;
    public UpdateUser?: number;
    public UpdateDate?: Date;
    public Gathering: number;
    public Organization = 0;
    public PalletNo: number;
    public ControlUser?: number;
    public Control?: Date;
    public ControlEndTime?: Date;
    public GatheringPalletStatus: number;
    public StoreName?: string;
    public OrderDate?: Date;
    public ShipmentDate?: Date;
    public StoreOrderName?: string;
    public GatheringTypeName?: string;
    public GatheringTypeId?: number;
    public ControlUserName?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.GatheringPalletId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.GatheringPalletId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
