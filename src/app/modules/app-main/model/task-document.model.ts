// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class TaskDocument extends ModelBase {
    public OverStoreTask = 0;
    public Document = 0;
    public CreateDate = new Date();
    public CreateUser = 0;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public OverStoreTaskOverStoreTaskId: number;
    public DocumentName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return new RelationId(this.OverStoreTask, this.Document);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
