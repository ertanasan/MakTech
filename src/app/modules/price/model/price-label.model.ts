import { ModelBase } from '@otmodel/model-base';

export class PriceLabel extends ModelBase {
    public ProductID = 0;
    public Code: string;
    public Name: string;
    public SaleVAT: number;
    public UnitName: string;
    public BarcodeType: string;
    public Barcode: number;
    public PrivateLabel: boolean;
    public eTrade: boolean;
    public ShortName: string;
    public Domestic: boolean;
    public Country: string;
    public Content: string;
    public Warning: string;
    public StorageCondition: string;
    public ExpiresIn: number;
    public ShelfLife: number;
    public Price: number;
    public TopPrice: number;
    public Print: boolean;
    public PriceChangeDate: Date;
    public Campaign: number;
    public UnitPrice: number;
    public WeightUnitName: string;
    public CurrentPriceId: number;
    public Package: number;
    public ImageContent?: string;
    public ImageFileName?: string;
    public ProductInfoUrl?: string;

    constructor() {
        super();
    }

    setId(id: number) {
        this.ProductID = id;
    }

    getId(): number {
        return this.ProductID;
    }
}
