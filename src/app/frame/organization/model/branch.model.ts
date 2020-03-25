// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Branch extends ModelBase {
    public BranchId = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Name: string;
    public Description?: string;
    public Type: number;
    public Organization: number;
    public Parent?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.BranchId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.BranchId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
