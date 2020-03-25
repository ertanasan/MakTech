// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class SignRequest extends ModelBase {
    public SignRequestId = 0;
    public Event: number;
    public Organization: number;
    public Deleted: boolean;
    public CreateDate: Date;
    public UpdateDate?: Date;
    public CreateUser: number;
    public UpdateUser?: number;
    public CreateChannel: number;
    public CreateBranch: number;
    public CreateScreen: number;
    public Status: number;
    public RawDocument: number;
    public SignedDocument: number;
    public SignAlgorithm: number;
    public AssignedGroup?: number;
    public AssignedUser?: number;
    public SerialSign: boolean;
    public DataFolder?: number;
    public Comment?: string;
    public Reference?: string;
    public ProcessInstance?: number;
    public AdditionalInfo?: string;
    public WorkingUser?: number;
    public WorkingExpirationTime?: Date;
    public Signer?: number;
    public SignInfo?: string;
    public SignTime?: Date;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.SignRequestId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.SignRequestId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
    /*Section="ClassFooter"*/
}
