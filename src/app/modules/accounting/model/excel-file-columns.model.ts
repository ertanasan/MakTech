// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ExcelFileColumns extends ModelBase {
    public ExcelFileColumnsId = 0;
    public ExcelFile: number;
    public ColumnName: string;
    public ColumnIndex: number;
    public ColumnType: number;
    public ColumnFormat?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ExcelFileColumnsId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ExcelFileColumnsId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
