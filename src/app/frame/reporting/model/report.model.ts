// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { ReportPanel } from './report-panel.model';

/*Section="ClassHeader"*/
export class Report extends ModelBase {
    public ReportId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Name: string;
    public Title: string;
    public Description?: string;
    public IsPublic: boolean;
    public Layout?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ReportId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.ReportId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    // tslint:disable-next-line:member-ordering
    public ReportPanels: ReportPanel[] = [];

    //#endregion Customized

    /*Section="ClassFooter"*/
}
