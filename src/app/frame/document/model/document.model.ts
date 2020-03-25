// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Document extends ModelBase {
    public DocumentId = 0;
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
    public Name: string;
    public Extention: string;
    public Status?: number;
    public DocumentType: number;
    public Repository: number;
    public BodyNo: number;
    public PreviousVersion?: number;
    public Size: number;
    public Path?: string;
    public Hash?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.DocumentId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.DocumentId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
