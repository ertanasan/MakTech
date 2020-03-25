import { ModelBase } from '@otmodel/model-base';

export class PackagePerformance extends ModelBase {
    public PackageId: number;
    public PriceChangePercentage = 0.0;
    public SaleChangePercentage = 0.0;
    public ProductCount = 0;
    public PerformanceDetailsGrid: any;

    constructor () {
        super();
    }

    setId(id: number) {
    }

    /*Section="Method-getId"*/
    getId(): number {
        return null;
    }
}
