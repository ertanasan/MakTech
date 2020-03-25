// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { GrowlMessageService } from '@otservice/growl-message.service';

import { PricePackage } from '@price/model/price-package.model';
import { CRUDMLService } from '@otservice/crudml.service';
import { ListParams } from '@otmodel/list-params.model';
import { process } from '@progress/kendo-data-query';
import { PackageType } from '@price/model/package-type.model';
import { PackagePerformance } from '@price/model/package-performans-model';

/*Section="ClassHeader"*/
@Injectable()
export class PricePackageService extends CRUDMLService<PricePackage> {

    public completeListExceptGeneral: PricePackage[];
    public campaingPerformanceLoading = false;

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Price', 'PricePackage');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    listAll(listParams: ListParams = null, action = 'ListAll') {
        if (this.loading) {
            return;
        }

        const resultSubscription = this.listAllAsync(action);
        this.loading = true;

        resultSubscription.subscribe(
            list => {
                this.completeList = list;
                // List Without GENEL FIYATLAR PAKETI
                const listExceptGeneral = this.completeList.filter(row=>row.PackageName !== 'GENEL FİYATLAR');
                this.completeListExceptGeneral = JSON.parse(JSON.stringify(listExceptGeneral));
                this.completeListChanged.next(this.completeList);
                // for (let i = 0; i < list.length; i++) {
                //     if (list[i].PackageName === 'GENEL FİYATLAR') {
                //         continue;
                //     } else {
                //         const tempPackageType = new PricePackage();
                //         Object.assign(tempPackageType, list[i]);
                //         this.completeListExceptGeneral.push(tempPackageType);
                //     }
                // }

                if (listParams) {
                    this.activeList = process(list, listParams);
                    this.activeListChanged.next(this.activeList);
                }
            },
            error => {
                this.messageService.error(error.message); // || this.translateService.get('Exception occured with an empty error message.'));
            },
            () => this.loading = false
        );
        return null;
    }

    getPackagePerformance(packageId: number) {
        const params = new HttpParams().append('packageId', packageId.toString());
        return this.httpClient.get<PackagePerformance>(this.baseRoute + 'PackagePerformance', { observe: 'body', responseType: 'json', params: params });
    }

    getImageContent(imageId: number) {
        const params = new HttpParams().append('imageId', imageId.toString());
        return this.httpClient.get<any>(this.baseRoute + 'GetImageContent', { observe: 'body', responseType: 'json', params: params });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
