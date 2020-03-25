// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class TransferProductDetail extends ModelBase {
    public TransferProductDetailId = 0;
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
    public Product: number;
    public TransferProduct = 0;
    public ProductQuantity: number;
    public Unit: number;
    public CreateId = 0;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.TransferProductDetailId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.TransferProductDetailId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
