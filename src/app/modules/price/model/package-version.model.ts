﻿// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';

/*Section="ClassHeader"*/
export class PackageVersion extends ModelBase {
    public PackageVersionId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Package: number;
    public VersionDate: Date;
    public ActiveFlag: boolean;
    public Comment?: string;
    public ActivationTime?: Date;
    public UpdateEnabled: boolean;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.PackageVersionId = id;
    }

    /*Section="Method-getId"*/
    getId(): number {
        return this.PackageVersionId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
