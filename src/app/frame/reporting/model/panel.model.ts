// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { ListParams } from '@otmodel/list-params.model';

/*Section="ClassHeader"*/
export class Panel extends ModelBase {
    public PanelId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Name: string;
    public Type: number;
    public TargetDB?: string;
    public DataSource: string;
    public ExecuteDynamic: boolean;
    public AdditionalParameters?: string;
    public Description?: string;
    public IsPublic: boolean;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.PanelId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.PanelId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.

    // tslint:disable-next-line:member-ordering
    public additionalParameters?: any;
    // tslint:disable-next-line:member-ordering
    public Columns: any[] = [];
    // tslint:disable-next-line:member-ordering
    public Filters: any[] = [];

    //#endregion Customized
    /*Section="ClassFooter"*/
}
