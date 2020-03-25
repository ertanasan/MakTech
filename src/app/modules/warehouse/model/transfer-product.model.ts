// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import { TransferProductDetail } from './transfer-product-detail.model';

/*Section="ClassHeader"*/
export class TransferProduct extends ModelBase {
    public TransferProductId = 0;
    public Event = 1053;
    public Organization = 1;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public SourceStore: number;
    public DestinationStore: number;
    public ProcessInstance?: number;
    public TransferStatus: number;
    public TransferDetails?: TransferProductDetail[] = [];
    public TransferToWarehouse = false;
    public WaybillNo?: string;
    public PreviousComment?: string;
    public ProcessStatus?: string;
    public TargetWarehouse?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.TransferProductId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.TransferProductId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
