// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { FirmContact } from '@accounting/model/firm-contact.model';
import {MainContactType} from '@contact/model/main-contact-type.model';
import {environment} from '../../../../environments/environment';
import {SubContactType} from '@contact/model/sub-contact-type.model';
import {observe} from '@progress/kendo-angular-grid/dist/es2015/utils';
import {Country} from '@contact/model/country.model';
import {City} from '@store/model/city.model';
import {RadioItem} from '@otuidataentry/radio-entry/radio-item';

/*Section="ClassHeader"*/
@Injectable()
export class FirmContactService extends CRUDLService<FirmContact> {
    mainTypeCompleteList: MainContactType[];
    mainTypeLoading = false;
    subContactTypeCompleteList: SubContactType[];
    subContactTypePartialList: SubContactType[][] = [];
    subTypeLoading = false;
    contactCompleteList: FirmContact[] = [];
    contactGroups = [];
    countryCompleteList: Country[];
    countryLoading = false;
    cityCompleteList: City[];
    cityLoading = false;

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Accounting', 'FirmContact');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    listAllMainType(): void {
        if (this.mainTypeLoading) {
            return;
        }
        this.mainTypeLoading = true;
        this.httpClient.get<MainContactType[]>(`${ environment.baseRoute }/Contact/MainContactType/` + 'ListAll', { responseType: 'json', observe: 'body'} ).subscribe(list => {
            this.mainTypeCompleteList = list;
            this.mainTypeLoading = false;
        });
    }

    listAllSubContactType(): void {
        if (this.subTypeLoading) {
            return;
        }
        this.httpClient.get<SubContactType[]>(`${ environment.baseRoute }/Contact/SubContactType/` + 'ListAll').subscribe(list => {
            this.subContactTypeCompleteList = list;
            this.subContactTypePartialList = [];
            this.subContactTypeCompleteList.map(sct => sct.MainContact).forEach(mcId => {
                this.subContactTypePartialList[mcId - 1] = this.subContactTypeCompleteList.filter(sct => sct.MainContact === mcId);
            });
            this.subTypeLoading = false;
        });
    }

    listAllCountry(): void {
        if (this.countryLoading) {
            return;
        }
        this.countryLoading = true;
        this.httpClient.get<Country[]>(`${ environment.baseRoute }/Contact/Country/` + 'ListAll').subscribe(list => {
            this.countryCompleteList = list;
            this.countryLoading = false;
        });
    }

    listAllCity(): void {
        if (this.cityLoading) {
            return;
        }
        this.cityLoading = true;
        this.httpClient.get<City[]>(`${ environment.baseRoute }/Contact/City/` + 'ListAll').subscribe(list => {
            this.cityCompleteList = list;
            this.cityLoading = false;
        });
    }

    listAllContactByFirmId(firmId: number): void {
        if (this.loading) {
            return;
        }
        this.loading = true;
        const params = new HttpParams().set('firmId', firmId.toString());
        this.httpClient.get<FirmContact[]>(this.baseRoute + 'ListAllContactByFirmId', { params: params }).subscribe(list => {
            this.contactCompleteList = list;
            this.contactGroups = [];
            this.contactGroups.push(list.filter(fc => fc.ContactObject.AddressContact));
            this.contactGroups.push(list.filter(fc => fc.ContactObject.PhoneContact));
            this.contactGroups.push(list.filter(fc => fc.ContactObject.WebContact));
            this.loading = false;
        });
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
