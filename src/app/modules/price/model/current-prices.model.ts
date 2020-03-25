// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class CurrentPrices extends ModelBase {
    public CurrentPricesId = 0;
    public StoreID: number;
    public ProductCodeName: string;
    public ProductName: string;
    public Barcode: string;
    public ProductUnit: number;
    public SalePrice: number;
    public SaleVAT: number;
    public VersionTime: Date;
    public StoreName: string;
    public GroupCode: number;
    public GroupCodeName?: string;
    public UnitName?: string;
    public PackageID?: number;
    public PackageName?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.CurrentPricesId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.CurrentPricesId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
