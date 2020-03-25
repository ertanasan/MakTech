// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class Title extends ModelBase {
    public TitleId = 0;
    public Organization: number;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Name: string;
    public Level?: number;
    public Parent?: number;
    public Description?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.TitleId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.TitleId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
