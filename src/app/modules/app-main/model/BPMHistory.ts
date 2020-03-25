import { ModelBase } from '@otmodel/model-base';

export class BPMHistory extends ModelBase {
    public CreateDate = new Date();
    public StartTime = new Date();
    public FinishTime = new Date();
    public Performer = 0;
    public ActionStatusCode = 0;
    public ProcessStatusCode = 0;
    public Choice: string;
    public ActionComment: string;
    public ProcessDefinitionName: string;
    public ActivityName: string;
    public ActivityTypeName: string;
    public ActivityNo: number;
    public ActivityStatusCode: string;
    public PerformerName: string;
    public TargetScopeName: string;
    public TargetName: string;

    constructor() {
        super();
    }

    getId(): number {
        return 0;
    }

    setId() {

    }
}
