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
export class ProcessDefinition extends ModelBase {

    public UpdateUser?: number;
    public Cancelable: boolean ;
    public IsSynchronous: boolean;
    public ExpirationDayCount: number;
    public Name: string;
    public Priority: number;
    public Area: number;
    public FriendlyName: string;
    public CreateUser: number;
    public UpdateDate?: Date ;
    public CreateDate: Date;
    public Deleted: boolean;
    public Organization: number;
    public ProcessDefinitionId: number;
    public ActiveVersion: number;

    constructor() {
        super();
    }
    getId(): number {
        return this.ProcessDefinitionId;
    }
    setId(id: number) {
       this.ProcessDefinitionId = id;
    }
    /*Section="Method-setId"*/
    /*Section="Method-getId"*/
    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
