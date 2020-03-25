// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { PackageType } from '@price/model/package-type.model';
import { ListParams } from '@otmodel/list-params.model';
import { process } from '@progress/kendo-data-query';

/*Section="ClassHeader"*/
@Injectable()
export class PackageTypeService extends CRUDLService<PackageType> {

    public completeListExceptGeneral: PackageType[];

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Price', 'PackageType');
    }

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
                const listExceptGeneral = this.completeList.filter(row=>row.PackageTypeName !== 'Genel Fiyatlar');
                this.completeListExceptGeneral = JSON.parse(JSON.stringify(listExceptGeneral));
                this.completeListChanged.next(this.completeList);
                // for (let i = 0; i < list.length; i++) {
                //     if (list[i].PackageTypeName === 'Genel Fiyatlar') {
                //         continue;
                //     } else {
                //         const tempPackageType = new PackageType();
                //         Object.assign(tempPackageType, list[i]);
                //         this.completeListExceptGeneral.push(tempPackageType);
                //     }
                // }
                // console.log(this.completeListExceptGeneral);
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

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    //#endregion Customized

    /*Section="ClassFooter"*/
}
