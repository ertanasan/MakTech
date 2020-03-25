import { ModelBase } from '@otmodel/model-base';

import { ActionAttribute } from './actionattribute.model';

export class InboxItem extends ModelBase {

    public ActivityInstanceStartTime: Date = new Date();
    public Performer?: number;
    public ParentProcessInstance?: number;
    public InstanceReference?: number;
    public ActivityInstance = 0;
    public ProcessInstance = 0;
    public ActivityNo = 0;
    public ProcessDefinition = 0;
    public ScreenReference = '';
    public HasDynamicForm = false;
    public ProcessInstanceStartDate: Date = new Date();
    public CreateDepartmentName = '';
    public CreateBranchName = '';
    public CreateUserName = '';
    public ActionStartDate: Date = new Date();
    public ActivityName = '';
    public ProcessDefinitionName = '';
    public ActionId = 0;
    public ProcessInstanceCreateUserName = '';
    public ActionFinishDate: Date = new Date();

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
