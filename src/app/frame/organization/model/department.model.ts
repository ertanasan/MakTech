// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Department extends ModelBase {
    public DepartmentId = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Name: string;
    public Type: number;
    public ShortName: string;
    public Organization?: number;
    public Parent?: number;
    public Description?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.DepartmentId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.DepartmentId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
