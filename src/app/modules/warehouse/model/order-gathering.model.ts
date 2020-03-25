import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

export class OrderGathering extends ModelBase {

    public ProductCodeName?: string;
    public ProductName?: string;
    public OrderQuantity?: number;
    public PalletNo?: number;
    public GatheringUserName?: string;
    public GatheringTime?: Date;
    public GatheredQuantity?: number;
    public GatheringStatus?: number;
    public ControlUserName?: string;
    public ControlTime?: Date;
    public ControlQuantity?: number;
    public ControlStatus?: number;
    public ProcessStatus?: number;
    public UnitName?: string;
    public Barcode?: string;
    public ShippedQuantity?: number;
    public Status?: number;

    constructor() {
        super();
    }

    setId(id: number) {
        
    }

    getId(): number | RelationId {
        return 1
    }

}

