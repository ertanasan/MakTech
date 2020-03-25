// Created by OverGenerator
/*Section="Imports"*/
import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

/*Section="ClassHeader"*/
export class StoreCashRegister extends ModelBase {
    public StoreCashRegisterId = 0;
    public Organization = 0;
    public Deleted = false;
    public CreateDate = new Date();
    public UpdateDate?: Date;
    public CreateUser = 0;
    public UpdateUser?: number;
    public Name: string;
    public Store: number;
    public CashRegisterModel: number;
    public PriceFilePath?: string;
    public SaleFilePath1?: string;
    public SaleFilePath2?: string;
    public SaleFilePath3?: string;
    public CurrentPriceVersion?: number;
    public CurrentPriceLoadTime?: Date;
    public PrivatePriceVersion?: number;
    public PrivatePriceLoadTime?: Date;
    public CreatePriceFileFlag?: boolean;
    public ModelName?: string;
    public ScaleBrandId?: string;
    public BrandName?: string;
    public IpAddress?: string;
    public Status?: boolean;
    public StatusText?: string;
    public GibDeviceNo?: string;
    public SerialNo?: string;
    public CashRegisterLongName?: string;

    constructor() {
        super();
    }

    /*Section="Method-setId"*/
    setId(id: number) {
        this.StoreCashRegisterId = id;
    }

    /*Section="Method-getId"*/
    getId(): number | RelationId {
        return this.StoreCashRegisterId;
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
