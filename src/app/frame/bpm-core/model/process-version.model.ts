// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { ActivityInstance } from './activity-instance.model';
import { EngineException } from './engine-exception.model';
import { Notification } from './notification.model';
import { Action } from './action.model';
import { Item } from './item.model';
import { ChildProcess } from './child-process.model';
import { Wait } from './wait.model';


/*Section="ClassHeader"*/
export class ProcessVersion extends ModelBase {

    public ProcessVersionId: number;
    public Organization: number ;
    public Deleted: boolean;
    public CreateDate: Date;
    public UpdateDate: Date;
    public ProcessDefinition: number;
    public Definition: string;
    public Version: number;
    public Diagram: string;

    constructor() {
        super();
    }
    getId(): number {
        return this.ProcessVersionId;
    }
    setId(id: number) {
       this.ProcessVersionId = id;
    }
    /*Section="Method-setId"*/
    /*Section="Method-getId"*/
    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
