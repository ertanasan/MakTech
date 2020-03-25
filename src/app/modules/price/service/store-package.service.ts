// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDMLService } from '@otservice/crudml.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StorePackage } from '@price/model/store-package.model';
import { Subject } from 'rxjs';
import { PricePackageService } from './price-package.service';

/*Section="ClassHeader"*/
@Injectable()
export class StorePackageService extends CRUDMLService<StorePackage> {
    public excludeInactivesSubject = new Subject<StorePackage[]>();

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public packageService: PricePackageService,
    ) {
        super(httpClient, messageService, translateService, 'Price', 'StorePackage');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.

    excludeInactives(storePackages: StorePackage[]) {
        this.packageService.listAllAsync().subscribe( packages => {
            const activePackageIdsArr = [];
            const fifteenDaysBefore = new Date();
            fifteenDaysBefore.setDate(fifteenDaysBefore.getDate() - 15);
            for (let i = 0; i < packages.length; i++) {
                if (packages[i].ActiveStores > 0 || packages[i].CreateDate >= fifteenDaysBefore) {
                    activePackageIdsArr.push(packages[i].PackageId);
                }
            }
            this.excludeInactivesSubject.next( storePackages.filter( s => activePackageIdsArr.includes(s.Package)) );
        });
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
