// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Uploads extends ModelBase {
    public UploadsId = 0;
    public Organization = 0;
    public Event = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public UploadType: number;
    public Status: number;
    public Folder: number;
    public UploadDate: Date;
    public ProcessDate: Date;
    public SourceRef: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.UploadsId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.UploadsId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
        
    /*Section="ClassFooter"*/
}
