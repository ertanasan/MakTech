import { ModelBase } from '@otmodel/model-base';
import { ActionAttribute } from './actionattribute.model';

export class WorkqueueItem extends ModelBase {

  public Performer?: number;     //
  public ParentProcessInstance?: number; //
  public InstanceReference?: string;   //
  public ActivityInstanceId = 0;  //
  public ProcessInstanceId = 0;   //
  public ScreenReference = '';   //
  public ProcessInstanceStartDate: Date = new Date();  //
  public ActivityName = '';  //
  public ProcessDefinitionName = '';  //
  public actionId = 0; //
  public CalculatedPriority = 0;  //
  public Priority = 0; //
  public FinishTime?: Date;
  public StartTime?: Date;
  public AssignTime?: Date;
  public WorkQueueName = '';
  public WorkQueueId = 0;
  public ItemId = 0;

  public ActionAttributes: ActionAttribute[] = [];

  constructor() {
    super();
  }
  getId(): number {
    return 0;
  }
  setId(id: number) {
  }
}
