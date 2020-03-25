import { ModelBase } from '@otmodel/model-base';
import { RelationId } from '@otmodel/relation-id.model';

export class StoreReconciliationIncome extends ModelBase {
    public CashRegister: string;
    public ZetNo: number
    public CashTotal: number;
    public CardTotal: number;
    public RefundTotal: number;
    public SaleTotal: number;

    constructor() {
        super();
    }

    setId(id: number) {
    }

    getId(): number | RelationId {
        return 0;
    }

}
