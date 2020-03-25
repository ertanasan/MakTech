import { FilterType } from './filter-type.model';
// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Filter extends ModelBase {
    public FilterId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public ParameterName: string;
    public Type: number;
    public LocalHeader?: string;
    public Header: string;
    public Panel: number;
    public Position: number;
    public AdditionalParameters?: string;
    public DefaultValue?: string;
    public MinimumValue?: string;
    public MaximumValue?: string;
    public Format?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.FilterId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.FilterId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.

    // tslint:disable-next-line:member-ordering
    public additionalParameters: any;

    // tslint:disable-next-line:member-ordering
    public TypeObject: FilterType;

    // tslint:disable-next-line:member-ordering
    public filterValue: any;
    //#endregion Customized

    /*Section="ClassFooter"*/
}
