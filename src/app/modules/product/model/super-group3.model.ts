// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class SuperGroup3 extends ModelBase {
    public SuperGroup3Id = 0;
    public SuperGroup3Name: string;
    public Comment?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SuperGroup3Id = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.SuperGroup3Id;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
        
    /*Section="ClassFooter"*/
}
