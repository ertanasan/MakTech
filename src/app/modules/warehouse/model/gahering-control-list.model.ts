import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

export class GatheringControlList extends ModelBase {

    public StoreOrderId?: number;
    public StoreName?: string;
    public OrderCodeName?: string;
    public OrderDate?: Date;
    public ShipmentDate?: Date;
    public ProductCount?: number;
    public OrderPriceAmount?: number;
    public PalletCount?: number;
    public TypeCount?: number;
    public GatheredTypeCount?: number;
    public GatheringPriceAmount?: number;
    public GatheredProductCount?: number;
    public ControlPalletCount?: number;
    public ControlledPalletCount?: number;
    public ControlPriceAmount?: number;
    public ControlledProductCount?: number;

    constructor() {
        super();
    }

    setId(id: number) {
        
    }

    getId(): number | RelationId {
        return 1
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
}

