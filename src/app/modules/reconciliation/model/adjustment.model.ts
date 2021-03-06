﻿// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Adjustment extends ModelBase {
    public AdjustmentId = 0;
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
    public Amount: number;
    public Description: string;
    public Date: Date;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.AdjustmentId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.AdjustmentId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
