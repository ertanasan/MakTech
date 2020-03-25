// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import { ProductionContent } from './production-content.model';

/*Section="ClassHeader"*/
export class ProductionOrder extends ModelBase {
    public ProductionOrderId = 0;
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
    public Production: number;
    public Quantity: number;
    public StatusCode: number;
    public ProcessInstance?: number;
    public CompletedQuantity?: number;
    public contents?: ProductionContent[];
    public PartialCompletion?: number;
    public ProductionOrderCost = 0;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ProductionOrderId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ProductionOrderId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
