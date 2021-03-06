﻿// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class City extends ModelBase {
    public CityId = 0;
    public CityName: string;
    public PlateCode?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.CityId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.CityId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized
        
    /*Section="ClassFooter"*/
}
