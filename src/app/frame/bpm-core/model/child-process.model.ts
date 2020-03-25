// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class ChildProcess extends ModelBase {
    public ProcessInstanceId: number;
    public ProcessDefinitionName: string;
    public Status: number;
    public StartDate?: Date;
    public FinishDate?: Date;
    public Parent?: number;




    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ProcessInstanceId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.ProcessInstanceId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
