import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Address extends ModelBase {
    public AddressId = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Organization = 0;
    public Contact = 0;
    public SubContactType = 0;
    public IsLocal = false;
    public Country = 0;
    public LocalCity?: number;
    public GlobalCityName: string;
    public CitySubDivision: string;
    public Street: string;
    public BuildingName: string;
    public BuildingNo: string;
    public RoomNo: string;
    public ZipCode: string;
    public Region: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.AddressId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.AddressId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
    /*Section="ClassFooter"*/
}
