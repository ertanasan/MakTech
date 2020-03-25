// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class ProcessArea extends ModelBase {

    public ProcessAreaId: number;
    public Organization: number;
    public Deleted: boolean;
    public CreateDate: Date;
    public UpdateDate?: Date ;
    public CreateUser: number;
    public UpdateUser?: number;
    public Name: string;
    public ShortName: string;
    public Description: string;

    constructor() {
        super();
    }
    getId(): number {
        return this.ProcessAreaId;
    }
    setId(id: number) {
       this.ProcessAreaId = id;
    }
    /*Section="Method-setId"*/
    /*Section="Method-getId"*/
    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
