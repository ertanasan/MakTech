import { ActivatedRoute, Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { Sales } from '@sale/model/sales.model';
import { ListParams } from '@otmodel/list-params.model';

class sale { storeId: number; date: Date; }
@Injectable()
export class SaleIdDate{
    public sale1 ;
    public params;
    constructor() {

    }
    set(sales: Sales) {
        this.sale1 = sales;
    }
    setParams(params: ListParams) {
        this.params = params;
    }
    get():any {

        return this.sale1;
        
    }
    getParams():any {

        return this.params;

    }
}