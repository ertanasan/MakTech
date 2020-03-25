// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class StorePackage extends ModelBase {
    public StorePackageId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Store: number;
    public Package: number;
    public PackageName?: string;
    public PriorityNumber: number;
    public IsCurrentFlag?: boolean;
    public CurrentVersion?: number;
    public StartTime: Date;
    public EndTime: Date;
    public StoreList: Number[];
    public AllStores: Boolean;
    public StoreName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StorePackageId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.StorePackageId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
    /*Section="ClassFooter"*/
}
