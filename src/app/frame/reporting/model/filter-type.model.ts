// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class FilterType extends ModelBase {
    public FilterTypeId = 0;
    public Name: string;
    public IsDynamic: boolean;
    public IsParameter: boolean;
    public Description?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.FilterTypeId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.FilterTypeId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
