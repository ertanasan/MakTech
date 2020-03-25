// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Product extends ModelBase {
    public ProductId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Code: string;
    public Name: string;
    public PurchaseVAT?: number;
    public SaleVAT: number;
    public Subgroup?: number;
    public SuperGroup1?: number;
    public SuperGroup2?: number;
    public SuperGroup3?: number;
    public Unit: number;
    public BarcodeType?: number;
    public SeasonType?: number;
    public OldCode?: string;
    public PrivateLabel = false;
    public eTrade = false;
    public GTIPCode?: string;
    public Photo?: Blob;
    public ShortName?: string;
    public Domestic = true;
    public Country?: number;
    public Content?: string;
    public Warning?: number;
    public StorageCondition?: number;
    public ExpiresIn?: number;
    public ShelfLife?: number;
    public Comment?: string;
    public Campaign?: number;
    public Weight?: number;
    public WeightUnit?: number;
    public Active = false;
    public LoadOrder?: string;
    public Parent?: number;
    public SearchString?: string;
    public InitialPrice?: number;
    public PackageQuantity?: number;
    public Category?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ProductId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ProductId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
