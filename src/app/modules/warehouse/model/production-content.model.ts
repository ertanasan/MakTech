// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ProductionContent extends ModelBase {
    public ProductionContentId = 0;
    public Production: number;
    public Product: number;
    public ShareRate: number;

    public ProductCode?: string;
    public ProductName?: string;
    public MainWarehouseStock?: number;
    public ProductionWarehouseStock?: number;
    public UnitWeightStr?: string;
    public UnitWeightList?: number[];
    public UnitWeight?: number;
    public RequiredPackage?: number;
    public AllocatedPackage?: number;
    public AllocatedQuantity?: number;
    public Remnant?: number;
    public UnitCost?: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ProductionContentId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ProductionContentId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
