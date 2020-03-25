// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Column extends ModelBase {
    public ColumnId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public FieldName: string;
    public LocalHeader?: string;
    public Header: string;
    public Panel: number;
    public Position: number;
    public AdditionalParameters?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ColumnId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.ColumnId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    // tslint:disable-next-line:member-ordering
    additionalParameters: any;
    /*Section="ClassFooter"*/
}
