// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';
import { DocumentHandle } from '@otmodel/document-handle.model';

/*Section="ClassHeader"*/
export class PricePackage extends ModelBase {
    public PackageId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public PackageName: string;
    public PackageType: number;
    public Comment?: string;
    public Image?: number;
    public ImageDocument = new DocumentHandle();
    public AllStores: number;
    public ActiveStores: number;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.PackageId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.PackageId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
