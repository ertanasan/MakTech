// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Folder extends ModelBase {
    public FolderId = 0;
    public Event = 0;
    public Organization: number;
    public Deleted = false;
    public CreationDate = new Date();
    public UpdateDate?: Date;
    public Creator = 0;
    public Updater?: number;
    public TransactionChannel = 0;
    public TransactionBranch = 0;
    public TransactionScreen = 0;
    public Template: number;
    public Reference: string;
    public Status?: number;
    public ArchiveIndicator?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.FolderId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.FolderId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
