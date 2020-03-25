// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class GatheringPalletPhoto extends ModelBase {
    public GatheringPalletPhotoId = 0;
    public Event = 1047;
    public Organization = 1;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public CreateChannel = 0;
    public CreateBranch = 0;
    public CreateScreen = 0;
    public GatheringPallet: number;
    public Photo: number;
    public PhotoContent: string;
    public PalletNo: number;
    public GatheringTypeName: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.GatheringPalletPhotoId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.GatheringPalletPhotoId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
