// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDMLService } from '@otservice/crudml.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { StoreProperty } from '@store/model/store-property.model';

/*Section="ClassHeader"*/
@Injectable()
export class StorePropertyService extends CRUDMLService<StoreProperty> {

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Store', 'StoreProperty');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    assingValuesToStores(propertyTypeId: number, assignValue: string, toStores: string) {
        if ( toStores === 'onlyNull') {
            // const params = new HttpParams().append('propertyId', propertyTypeId.toString());
            // params.append('value', assignValue);
            // this.httpClient.post(this.baseRoute + 'CreateStorePropertyForAllStores', { propertyTypeId: propertyTypeId, value: assignValue }).subscribe(
            this.httpClient.post(this.baseRoute + 'CreateStorePropertyForAllStores/' + propertyTypeId + '/' + assignValue, null).subscribe(
                a => {
                    if (a !== 0) {
                        this.messageService.success(`Store property saved as "${assignValue}" for ${a} stores with no values`);
                    }
                },
                error => {
                    this.messageService.error(`Store property couldn't be saved. Error: ${error}`);
                }
            );
        } else if ( toStores === 'all' ) {
            this.httpClient.put(this.baseRoute + 'UpdateStorePropertyForAllStores/' + propertyTypeId + '/' + assignValue, null).subscribe(
                a => {
                    if (a !== 0) {
                        this.messageService.success(`Store property updated as "${assignValue}" for ${a} stores with any value`);
                    } else {
                        this.messageService.info(`All existing values are already "${assignValue}"; so no change applied`);
                    }
                },
                error => {
                    this.messageService.error(`Store property couldn't be updated. Error: ${error}`);
                }
            );

            this.httpClient.post(this.baseRoute + 'CreateStorePropertyForAllStores/' + propertyTypeId + '/' + assignValue, null).subscribe(
                a => {
                    if (a !== 0) {
                        this.messageService.success(`Store property saved as "${assignValue}" for ${a} stores with no values`);
                    }
                },
                error => {
                    this.messageService.error(`Store property couldn't be saved. Error: ${error}`);
                }
            );
        }
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
