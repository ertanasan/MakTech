﻿// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class ProductShipmentUnit extends ModelBase {
    public ProductShipmentUnitId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Product: number;
    public ShipmentType: number;
    public PackageQuantity: number;
    public PackageType: number;
    // public WarehouseLocation?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.ProductShipmentUnitId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.ProductShipmentUnitId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
