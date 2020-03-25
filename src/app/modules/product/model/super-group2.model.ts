// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class SuperGroup2 extends ModelBase {
    public SuperGroup2Id = 0;
    public SuperGroup2Name: string;
    public Comment?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SuperGroup2Id = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.SuperGroup2Id;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
        
    /*Section="ClassFooter"*/
}
