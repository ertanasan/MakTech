// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { PriceLabelPrint } from '@price/model/price-label-print.model';
import { PriceLabel } from '@price/model/price-label.model';
import { Subscription } from 'rxjs';
import { environment } from 'environments/environment';

/*Section="ClassHeader"*/
@Injectable()
export class PriceLabelPrintService extends CRUDLService<PriceLabelPrint> {

    printedLabelsRawData: any;
    printedLabelsActiveList: any;

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Price', 'PriceLabelPrint');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    markAsPrinted(labelList: PriceLabel[], labelSize: string) {
        const printedRows = [];
        labelList.forEach(label => {
            const tempLabelPrintItem = this.convertToPrintItem(label, labelSize);
            printedRows.push(tempLabelPrintItem);
        });
        this.httpClient.post<PriceLabelPrint[]>(`${ environment.baseRoute }/Price/PriceLabelPrint/InsertPrintedLabels`, printedRows).subscribe();
    }

    convertToPrintItem(label: PriceLabel, labelSize: string): PriceLabelPrint {
        const tempLabelPrintItem: PriceLabelPrint = new PriceLabelPrint();
        // tempLabelPrintItem.LabelPrintId = 0;
        // tempLabelPrintItem.Event = 1049;
        // tempLabelPrintItem.Organization = 1;
        // tempLabelPrintItem.Deleted = false;
        // tempLabelPrintItem.CreateDate = new Date();
        // // tempLabelPrintItem.UpdateDate?: Date;
        // tempLabelPrintItem.CreateUser = 0;
        // // tempLabelPrintItem.UpdateUser?: number;
        // tempLabelPrintItem.CreateChannel = 0;
        // tempLabelPrintItem.CreateBranch = 0;
        // tempLabelPrintItem.CreateScreen = 0;
        tempLabelPrintItem.Product = label.ProductID;
        tempLabelPrintItem.CurrentPrice = label.CurrentPriceId;
        tempLabelPrintItem.LabelSize = labelSize;

        return tempLabelPrintItem;
    }

    listPrintedLabels() {
        return this.httpClient.get<any>(this.baseRoute + '/ListPrintedLabels', { observe: 'body', responseType: 'json' });
    }

    getPrintedLabelDetails (storeId: number) {
        const params = new HttpParams().set('storeId', storeId.toString());
        return this.httpClient.get<any>(this.baseRoute + 'ListPrintedLabelDetailsByStore', { observe: 'body', responseType: 'json', params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
