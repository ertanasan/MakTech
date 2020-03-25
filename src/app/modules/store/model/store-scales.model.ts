// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class StoreScales extends ModelBase {
    public StoreScalesId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Name: string;
    public Store: number;
    public ScaleModel: number;
    public PriceFilePath?: string;
    public CurrentPriceVersion?: number;
    public CurrentPriceLoadTime?: Date;
    public PrivatePriceVersion?: number;
    public PrivatePriceLoadTime?: Date;
    public CreatePriceFileFlag?: boolean;
    public ModelName?: string;
    public ScaleBrandId?: string;
    public BrandName?: string;
    public IpAdress?: string;
    public Status?: boolean;
    public StatusText?: string;
    public SerialNumber?: string;
    public ScaleLongName?: string;
    public SealValidDate?: Date;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StoreScalesId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StoreScalesId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
