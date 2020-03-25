// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ExpenseType extends ModelBase {
    public ExpenseTypeId = 0;
    public ExpenseTypeName: string;
    public AccountCode?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ExpenseTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ExpenseTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
