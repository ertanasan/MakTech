// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ConstraintException extends ModelBase {
    public ConstraintExceptionId = 0;
    public Store: number;
    public StartDate: Date;
    public EndDate: Date;
    public Category?: number;
    public SubGroup?: number;
    public Product?: number;
    public Coefficient: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ConstraintExceptionId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ConstraintExceptionId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
