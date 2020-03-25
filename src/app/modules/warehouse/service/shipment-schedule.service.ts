// Created by OverGenerator
/*Section="Imports"*/
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TranslateService } from '@ngx-translate/core';

import { CRUDLService } from '@otservice/crudl.service';
import { GrowlMessageService } from '@otservice/growl-message.service';

import { ShipmentSchedule } from '@warehouse/model/shipment-schedule.model';
import { CRUDMLService } from '@otservice/crudml.service';

/*Section="ClassHeader"*/
@Injectable()
export class ShipmentScheduleService extends CRUDMLService<ShipmentSchedule> {

    scheduleDays = {
        monday: false,
        tuesday: false,
        wednesday: false,
        thursday: false,
        friday: false,
        saturday: false,
        sunday: false
    };

    constructor(
        httpClient: HttpClient,
        messageService: GrowlMessageService,
        translateService: TranslateService,
    ) {
        super(httpClient, messageService, translateService, 'Warehouse', 'ShipmentSchedule');
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized

    convertScheduleTxtToBooleanDays(schduleTxt: String) {
        this.scheduleDays.monday = (schduleTxt.slice(0, 1) === '1');
        this.scheduleDays.tuesday = (schduleTxt.slice(2, 3) === '1');
        this.scheduleDays.wednesday = (schduleTxt.slice(4, 5) === '1');
        this.scheduleDays.thursday = (schduleTxt.slice(6, 7) === '1');
        this.scheduleDays.friday = (schduleTxt.slice(8, 9) === '1');
        this.scheduleDays.saturday = (schduleTxt.slice(10, 11) === '1');
        this.scheduleDays.sunday = (schduleTxt.slice(12, 13) === '1');
    }

    revertToScheduleTxt() {
        let txt = '';
        txt += this.scheduleDays.monday     ? '1-' : '0-';
        txt += this.scheduleDays.tuesday    ? '1-' : '0-';
        txt += this.scheduleDays.wednesday  ? '1-' : '0-';
        txt += this.scheduleDays.thursday   ? '1-' : '0-';
        txt += this.scheduleDays.friday     ? '1-' : '0-';
        txt += this.scheduleDays.saturday   ? '1-' : '0-';
        txt += this.scheduleDays.sunday     ? '1' : '0';
        return txt;
    }

    assingScheduleDays(formValues: any) {
        this.scheduleDays.monday = formValues.Monday;
        this.scheduleDays.tuesday = formValues.Tuesday;
        this.scheduleDays.wednesday = formValues.Wednesday;
        this.scheduleDays.thursday = formValues.Thursday;
        this.scheduleDays.friday = formValues.Friday;
        this.scheduleDays.saturday = formValues.Saturday;
        this.scheduleDays.sunday = formValues.Sunday;
    }

    //#endregion Customized

    /*Section="ClassFooter"*/
}
