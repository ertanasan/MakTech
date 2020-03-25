// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class User extends ModelBase {
    public UserId = 0;
    public Organization: number;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Name: string;
    public Password: string;
    public SecurityStamp?: string;
    public UserFullName?: string;
    public Department: number;
    public Branch: number;
    public Profession: number;
    public Title: number;
    public Manager?: number;
    public TechnicalManager?: number;
    public Location?: number;
    public Gender?: string;
    public Photo?: Blob;
    public EMail?: string;
    public Description?: string;
    public AccessDeniedCount?: number;
    public Active: boolean;
    public UserOSName?: string;
    public NationalIdentityNo?: string;
    public PhoneNumber?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.UserId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.UserId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
