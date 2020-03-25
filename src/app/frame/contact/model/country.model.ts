// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Country extends ModelBase {
    public CountryId = 0;
    public Name: string;
    public InternationalCode: string;
    public UseCityList: boolean;
    public PhoneCode?: string;
    public Description?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.CountryId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.CountryId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
