// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Repository extends ModelBase {
    public RepositoryId = 0;
    public Name: string;
    public RepositoryType: number;
    public Address?: string;
    public Description?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.RepositoryId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.RepositoryId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
        
    /*Section="ClassFooter"*/
}
