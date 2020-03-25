import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

export class ZControlLog extends ModelBase {
    public ZControlLogId = 0;
    public CreateDate: Date;
    public CreateUser: number;
    public Store: number;
    public ReconciliationDate: Date;
    public ZetAmount: number;

    constructor() {
        super();
    }

    setId(id: number) {
        this.ZControlLogId = id;
    }

    getId(): number | RelationId {
        return this.ZControlLogId;
    }

}
