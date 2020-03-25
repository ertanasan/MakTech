import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { StoreReconciliation } from '@reconciliation/model/store-reconciliation.model';
import { saveAs } from 'file-saver';
//import { StoreReconciliationIncome } from '@reconciliation/model/store-reconciliation-income.model';

@Injectable()
export class StoreReconciliationService extends CRUDLService<StoreReconciliation> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Reconciliation', 'StoreReconciliation');
    }

    //storeReconciliationIncome: StoreReconciliationIncome[];
    reconciliations: any ;//StoreReconciliation;
    reconciliations_filtered: any;

    // getStoreReconciliationIncome(transactionDate: Date) {
    //     let p = new HttpParams();
    //     p = p.append('transactionDate', new Date(transactionDate).toJSON());
    //     let req = this.httpClient.get<StoreReconciliationIncome[]>(this.baseRoute + 'StoreReconciliationIncome', { observe: 'body', responseType: 'json', params: p });
        
    //     req.subscribe
    //     (
    //         result => {
    //             this.storeReconciliationIncome = result;
    //         }
    //     );
    //     return req;
    // }

    getStoreReconciliationList(transactionDate: Date) {
        let p = new HttpParams();
        p = p.append('transactionDate', new Date(transactionDate).toJSON());
        let req = this.httpClient.get(this.baseRoute + 'StoreReconciliationList', { observe: 'body', responseType: 'json', params: p });
        
        req.subscribe
        (
            result => {
                this.reconciliations = result;
                this.reconciliations_filtered = result;
            }
        );
        return req;
    }

    getStoreReconciliation(transactionDate: Date) {
        let p = new HttpParams();
        p = p.append('transactionDate', new Date(transactionDate).toJSON());
        return  this.httpClient.get<StoreReconciliation>(this.baseRoute + 'StoreReconciliation', { observe: 'body', responseType: 'json', params: p });
    }

    saveReconciliation(transactionDate: Date, reconciliation) {
        reconciliation.TransactionDate = transactionDate;
        this.httpClient.post(this.baseRoute + 'StoreReconciliationSave', reconciliation).subscribe(
            model => {
                this.messageService.success(`Reconciliation saved.`);
            },
            error => {
                this.messageService.error(`Reconciliation Failed. Error: ${error}.`);
            }
        );
    };

    deleteReconciliation(reconciliationID: string) {
        let p = new HttpParams();
        p = p.append('reconciliationID', reconciliationID);
        return this.httpClient.get(this.baseRoute + 'StoreReconciliationDelete', { observe: 'body', responseType: 'json', params: p });
    }

    approveReconciliations(transactionDate: Date, reconciliationID:string) {
        let p = new HttpParams();
        p = p.append('transactionDate', new Date(transactionDate).toJSON());
        p = p.append('reconciliationID', reconciliationID);
        return this.httpClient.get(this.baseRoute + 'ApproveReconciliations', { observe: 'body', responseType: 'json', params: p });
    }

    // exportReconciliations(reconciliations) {


    //     this.httpClient.post(this.baseRoute + 'ExportReconciliations', reconciliations).subscribe(
    //         blob => {
    //             saveAs(blob, 'Mutabakat' + '.xlsx');
    //             this.messageService.success('İşlem tamamlandı.');
    //         },
    //         error => {
    //             this.messageService.error(`${error}xxxxxxxxxxxxx.`);
    //         }
    //     );
    // }
    
    getReconciliationStoreData(dayGroup) {
        let params = new HttpParams();
        params = params.append('dayGroup', dayGroup);
        return this.httpClient.get<any>(this.baseRoute + 'ReconciliationStoreData', { observe: 'body', responseType: 'json', params: params });
    }
}