// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Store extends ModelBase {
    public StoreId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Name: string;
    public OrganizationBranch: number;
    public IpAddress: string;
    public Advance: number;
    public OpeningDate?: Date;
    public ClosingDate?: Date;
    public ActiveFlag = false;
    public ProductionFlag = false;
    public City?: number;
    public Town?: number;
    public Address?: string;
    public RegionManager?: number;
    public InConstruction = false;
    public CityName?: string;
    public TownName?: string;
    public RegionManagerName?: string;
    public LastOrderEntry?: number;
    public UserBranchType?: string;
    public TerminalCount?: number;
    public UserDepartment?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StoreId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StoreId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}