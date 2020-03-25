// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class SuperGroup1 extends ModelBase {
    public SuperGroup1Id = 0;
    public SuperGroup1Name: string;
    public Comment?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SuperGroup1Id = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.SuperGroup1Id;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
        
    /*Section="ClassFooter"*/
}
