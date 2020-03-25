// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class RegionManagers extends ModelBase {
    public RegionManagersId = 0;
    public RegionManagerName: string;
    public TelNo?: string;
    public Email?: string;
    public RegionUser?: number;
    public ExpenseAccountCode?: string;
    public UserActive?: boolean;
    public RegionName?: string;
    public MikroProjectCode?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.RegionManagersId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.RegionManagersId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
