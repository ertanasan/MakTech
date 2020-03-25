import { ModelBase } from '@otmodel/model-base';

export class Profile extends ModelBase {

    constructor(public UserFullName: string, public Roles: string[]) {
        super();
    }

    getId(): number {
        return 0;
    }

    setId() {

    }
}
