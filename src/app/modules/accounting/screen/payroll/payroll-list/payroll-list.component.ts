// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Payroll } from '@accounting/model/payroll.model';
import { PayrollService } from '@accounting/service/payroll.service';
import { PayrollEditComponent } from '@accounting/screen/payroll/payroll-edit/payroll-edit.component';
import { HttpErrorResponse } from '@angular/common/http';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DatePipe } from '@angular/common';
import { process } from '@progress/kendo-data-query';
import * as _ from 'lodash';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-payroll-list',
    templateUrl: './payroll-list.component.html',
    styleUrls: ['./payroll-list.component.css', ]
})
export class PayrollListComponent extends ListScreenBase<Payroll> implements OnInit, AfterViewInit {
    @ViewChild(PayrollEditComponent, {static: true}) editScreen: PayrollEditComponent;

    settings: Array<any> = [{text: 'Tümünü Aktar'}];
    checkedList =  [];
    selectedYear: number = (new Date()).getFullYear();
    selectedMonth: number = (new Date()).getMonth();
    payrollList: any;
    payrollActiveList: any;


    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: PayrollService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        this.listParams.take = 11;
        if (this.payrollList) {
            this.payrollActiveList = process(this.payrollList, this.listParams);
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Accounting' }, {Caption: 'Payroll', RouterLink: '/accounting/payroll'}];
    }

    createEmptyModel(): Payroll {
        return new Payroll();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    getMonthList() {
        if (this.selectedYear && this.selectedMonth) {
            this.dataService.loading = true;
            this.dataService.listMonth(this.selectedYear, this.selectedMonth).subscribe(result => {
                this.payrollList = result;
                ((<Payroll[]>this.payrollList)).map(t => {
                    t.StartDate = new Date(t.StartDate);
                    t.QuitDate = new Date(t.QuitDate);
                });
                this.refreshList();
                this.dataService.loading = false;
            },
            error => {
                this.messageService.error(error);
                this.dataService.loading = false;
            });
        }
    }

    onFileSelected(event) {
        this.dataService.loading = true;
        const formData = new FormData();
        formData.append('file[]', event.target.files[0]);
        this.dataService.loadHRFile(formData).subscribe(result => {
            // console.log('result ', result);
            this.dataService.loading = false;
            if (!result || result === '') {
                this.messageService.success('Veriler sisteme başarılı bir şekilde aktarıldı.');
            } else {
                this.messageService.error(result.toString());
            }
            event.target.value = '';
            this.refreshList();
        }, (error: HttpErrorResponse) => {
            console.log('error ', error);
            this.dataService.loading = false;
            this.messageService.error(error.error);
            event.target.value = '';
        });
    }

    public onMikro(event) {

        this.dataService.MikroTransfer(this.selectedYear, this.selectedMonth).subscribe(
            result => {
                this.messageService.success(this.translateService.instant(`Transferred to Mikro`));
                this.getMonthList();
            }, (error: HttpErrorResponse) => {
                console.log(error);
                this.messageService.error(this.translateService.instant(`An error occured while transferring-${error.error}`));
        });
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['StartDate', 'QuitDate'];
        super.handleDataStateChange(state);
    }

    onYearChange(year) {
        this.selectedYear = year;
    }

    onMonthChange(month) {
        this.selectedMonth = month;
    }

    ngOnInit() {
        super.ngOnInit();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
