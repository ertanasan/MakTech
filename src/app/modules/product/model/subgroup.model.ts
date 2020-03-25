// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Subgroup extends ModelBase {
    public SubgroupID = 0;
    public SubgroupName: string;
    public Category: number;
    public Comment?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SubgroupID = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.SubgroupID;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
