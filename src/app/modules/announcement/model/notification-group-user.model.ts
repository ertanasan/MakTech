﻿// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class NotificationGroupUser extends ModelBase {
    public NotificationGroup = 0;
    public User = 0;
    public CreateDate = new Date();
    public CreateUser = 0;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public NotificationGroupGroupName: string;
    public UserName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return new RelationId(this.NotificationGroup, this.User);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
