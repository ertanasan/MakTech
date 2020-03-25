// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Package extends ModelBase {
    public PackageId = 0;
    public Name: string;
    public ParentPackage?: number;
    public Amount: number;
    public Description?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.PackageId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.PackageId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
