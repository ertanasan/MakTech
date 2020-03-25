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
import { ActionHistoryItem } from './action-history-item.model';
import { DocumentHandle } from '@otmodel/document-handle.model';


/*Section="ClassHeader"*/
export class ProcessInstanceExtended extends ModelBase {

    public ProcessDefinitionName: string;
    public VersionNo: number;
    public Activities: ActivityInstance[] = [];
    public Exceptions: EngineException[] = [];
    public Notifications: Notification[] = [];
    public Actions: Action[] = [];
    public ActionHistoryItems: ActionHistoryItem[] = [];
    public Items: Item[] = [];
    public Children: ChildProcess[] = [];
    public Waits: Wait[] = [];
    public InstanceXml: string;
    public InputXml: string;
    public ActionDataXml: string;
    public TransactionScreen: number;
    public ParentActivity?: number;
    public Parent?: number;
    public StartDate?: Date;
    public FinishDate?: Date;
    public IsSynchronized: boolean;
    public Status: number;
    public ProcessDefinition: number;
    public TransactionBranch: number;
    public InstanceReference: string;
    public TransactionChannel: number;
    public Updater?: number;
    public Creator: number;
    public UpdateDate?: Date;
    public CreationDate: Date;
    public Event: number;
    public ProcessInstanceId = 0;
    public Organization: number;
    public Deleted: boolean;
    public InstanceDocumentHandle: DocumentHandle;

    constructor() {
        super();
    }
    getId(): number {
        return this.ProcessInstanceId;
    }
    setId(id: number) {
       this.ProcessInstanceId = id;
    }
    /*Section="Method-setId"*/
    /*Section="Method-getId"*/
    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
