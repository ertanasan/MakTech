import { RelationId } from '@otmodel/relation-id.model';
import { ModelBase } from '@otmodel/model-base';

export class RequestBPM extends ModelBase {

    public ActionId?: number;
    public ScreenReference?: string;
    constructor() {
        super();
    }

    setId(id: number) {
        
    }

    getId(): number | RelationId {
        return 1
    }

}
