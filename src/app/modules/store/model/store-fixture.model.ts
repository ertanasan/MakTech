// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class StoreFixture extends ModelBase {
    public StoreFixtureId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public ProductFixture: number;
    public PurchaseDate?: Date;
    public SerialNo?: string;
    public EndOfGuaranteeDate?: Date;
    public Supplier?: number;
    public Store: number;
    public FixtureName: string;
    public Brand?: number;
    public Model?: number;
    public FixtureLongName?: string;
    public Quantity?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StoreFixtureId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StoreFixtureId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
