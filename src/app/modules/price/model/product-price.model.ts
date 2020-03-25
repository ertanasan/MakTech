// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class ProductPrice extends ModelBase {
    public ProductPriceId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public PriceType: number;
    public OldPriceAmount: number;
    public PriceAmount: number;
    public CurrentPriceAmount: number;
    // public IncludedFlag: boolean;
    public Product: number;
    public ProductName: string;
    public ProductCodeName: string;
    public Plu1: string;
    public Plu2: string;
    public Plu3: string;
    public SaleVATRate: number;
    public Unit: number;
    public ProductFamilyName: string;
    public ProductTypeName: string;
    public Package: number;
    public OldTopPriceAmount?: number;
    public TopPriceAmount?: number;
    public OldPrintTopPriceFlag: boolean;
    public PrintTopPriceFlag: boolean;
    public PackageVersion: number;
    // public PriceChanged: boolean;
    public OldPackageProduct: boolean;
    public PackageProduct: boolean;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ProductPriceId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.ProductPriceId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
    /*Section="ClassFooter"*/
}


