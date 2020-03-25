// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import { RequestDetail } from './request-detail.model';
import { AttributeChoice } from './attribute-choice.model';
import { AssignUser } from './assign-user.model';

/*Section="ClassHeader"*/
export class HelpdeskRequest extends ModelBase {
    public HelpdeskRequestId = 0;
    public Event = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public RequestDefinition: number;
    public RequestDescription?: string;
    public StatusCode: number;
    public ProcessInstance?: number;
    public Store: number;
    public RedirectionGroup?: number;
    public RequestDetailList?: RequestDetail[];
    public Process?: number;
    public ProcessName?: string;
    public RequestGroup?: number;
    public StoreName?: string;
    public ProcessInstanceStatusCode?: number;
    public ActivityName?: string;
    public ContactPhoneNumber?: string;
    public ResponsibleUser?: number;
    public UserList?: AssignUser[];
    public AdminFlag?: boolean;
    public UserTask?: boolean;

    public Info1?: any;
    public Info2?: any;
    public Info3?: any;
    public Info4?: any;
    public Info5?: any;
    public Info6?: any;
    public Info7?: any;
    public Info8?: any;
    public Info9?: any;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.HelpdeskRequestId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.HelpdeskRequestId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}

export class HeldeskRequestInfo {
    attributeId: number;
    type: number;
    text: string;
    control: string;
    dropdownlist: AttributeChoice[];
    value: any;
    displayorder: number;
    required: boolean;
}
