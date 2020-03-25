// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class StoreOrder extends ModelBase {
    public StoreOrderId = 0;
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
    public Store: number;
    public OrderCode: string;
    public Status: number;
    public OrderDate: Date;
    public ShipmentDate: Date;
    public ApproveEnabled?: boolean;
    public PrintEnabled?: boolean;
    public ShipmentEnabled?: boolean;
    public EditDetailsEnabled?: boolean;
    public StoreName?: string;
    public FirstEntryUser?: string;
    public LastApproveUser?: string;
    public Controller?: string;
    public DispatchUser?: string;
    public FirstEntryTime?: Date;
    public LastApproveTime?: Date;
    public ControlTime?: Date;
    public DispatchTime?: Date;
    public AuthorizationLevel?: number;
    public OrderValue?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StoreOrderId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StoreOrderId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
