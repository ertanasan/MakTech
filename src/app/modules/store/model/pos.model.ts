// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class Pos extends ModelBase {
    public PosId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Store: number;
    public PosCode: string;
    public Bank?: number;
    public CashRegisterCode?: string;
    public BankCode?: string;
    public Description?: string;
    public MobilFlag = false;
    public StoreName?: string;
    public BankName?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.PosId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.PosId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
