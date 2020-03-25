// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class ActionHistoryItem extends ModelBase {
    public ActivityName: string;
    public ActionPerformer: string;
    public Choice: string;
    public UserComment: number;
    public StartDate: Date;
    public FinishDate?: Date;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {

    }

    /*Section="Method-getId"*/
    getId(): number {
        return 0;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
