// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class AssignUser extends ModelBase {
    public AssignUserId = 0;
    public GroupName: string;
    public ResponsibleUser: number;
    public AdminFlag: boolean;
    public UserName?: string;
    public UserFullName?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.AssignUserId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.AssignUserId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
