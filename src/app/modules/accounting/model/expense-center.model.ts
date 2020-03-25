// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ExpenseCenter extends ModelBase {
    public ExpenseCenterId = 0;
    public ExpenseCenterName: string;
    public ExpenseCenterCode: string;
    public ExpenseCenterGroup: number;
    public RegionManager?: number;
    public Store?: number;
    public ActiveFlag: boolean;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ExpenseCenterId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ExpenseCenterId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
