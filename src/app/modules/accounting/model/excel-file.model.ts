// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ExcelFile extends ModelBase {
    public ExcelFileId = 0;
    public TransferName: string;
    public SheetNo: number;
    public RowStartNo: number;
    public ColumnStartNo: number;
    public NumberOfColumns: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ExcelFileId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ExcelFileId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
