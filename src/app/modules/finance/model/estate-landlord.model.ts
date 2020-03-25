// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class EstateLandlord extends ModelBase {
    public EstateRent = 0;
    public Landlord = 0;
    public CreateDate = new Date();
    public CreateUser = 0;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public OwnershipRate?: number;
    public PaymentRate?: number;
    public IBAN?: string;
    public EstateRentEstateRentId: number;
    public LandlordLandlordName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return new RelationId(this.EstateRent, this.Landlord);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
