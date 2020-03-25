import { RelationId } from './relation-id.model';

export abstract class ModelBase {
    public action = 0;
    public actionComment = '';
    public actionChoice = '';
    abstract getId(): number | RelationId;
    abstract setId(id: number);
}
