// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class ReportPanel extends ModelBase {
    public Report = 0;
    public Panel = 0;
    public CreationDate = new Date();
    public Creator = 0;
    public TransactionChannel = 0;
    public TransactionBranch = 0;
    public TransactionScreen = 0;
    public Position: number;
    public Width: number;
    public RawDataVisible: boolean;
    public ExportEnabled: boolean;
    public ReportName: string;
    public PanelName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
    }

    /*Section="Method-getId"*/
    getId(): number {
        throw Error();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
    /*Section="ClassFooter"*/
}
