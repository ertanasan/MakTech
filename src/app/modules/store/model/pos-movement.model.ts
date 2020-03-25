// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class PosMovement extends ModelBase {
    public PosMovementId = 0;
    public PosId: number;
    public Organization = 0;
    public Deleted = false;
    public MoveTime: Date;
    public Store: number;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public LagStore?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.PosMovementId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.PosMovementId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
