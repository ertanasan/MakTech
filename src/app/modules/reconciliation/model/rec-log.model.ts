import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

export class RecLog extends ModelBase {
    public Id = 0;
    public LogDate: Date;
    public LogUserName?: string;
    public StepText?: string;

    constructor() {
        super();
    }

    setId(id: number) {
        this.Id = id;
    }

    getId(): number | RelationId {
        return this.Id;
    }

}
