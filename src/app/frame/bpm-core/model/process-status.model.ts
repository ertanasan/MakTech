// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class ProcessStatus extends ModelBase {
    public ProcessStatusId: number;
    public Name: string;
    public Comment: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ProcessStatusId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.ProcessStatusId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
