// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { EstateRentPeriod } from '@finance/model/estate-rent-period.model';
import { EstateRentPeriodService } from '@finance/service/estate-rent-period.service';
import { EstateRentPeriodEditComponent } from '@finance/screen/estate-rent-period/estate-rent-period-edit/estate-rent-period-edit.component';
import {finalize} from 'rxjs/operators';
import {DataStateChangeEvent} from '@progress/kendo-angular-grid';
import {Currencies} from '../../../../../util/shared-enums.component';
import {CustomDialogComponent} from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-estate-rent-period-list',
    templateUrl: './estate-rent-period-list.component.html',
    styleUrls: ['./estate-rent-period-list.component.css', ]
})
export class EstateRentPeriodListComponent extends ListScreenBase<EstateRentPeriod> implements AfterViewInit {
    @ViewChild(EstateRentPeriodEditComponent, { static: true }) editScreen: EstateRentPeriodEditComponent;
    @ViewChild('getConsent', {static: true}) getConsent: CustomDialogComponent;
    currencies = Currencies;
    isKeepExistingPeriods = true;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: EstateRentPeriodService,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        if (this.isEmbedded) {
            this.listParams.pageable = false;
            this.listParams.skip = 0;
            this.listParams.take = 200;
        }
        const result = this.dataService.listByMasterAsync(this.listParams, this.masterId);
        if (result) {
            this.dataLoading = true;
            result.pipe(
                finalize(() => this.dataLoading = false)
            ).subscribe(
                list => {
                    this.dataList = <EstateRentPeriod[]>list.Data;
                },
                error => {
                    this.messageService.error(error.message || this.translateService.get('Error occured with undefined message.'));
                }
            );
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Finance' }, {Caption: 'Estate Rent Period', RouterLink: '/finance/estate-rent-period'}];
    }

    createEmptyModel(): EstateRentPeriod {
        const estateRentPeriod = new EstateRentPeriod();
        if (this.masterId) {
            estateRentPeriod.EstateRent = this.masterId;
        }
        return estateRentPeriod;
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    // Keep your custom code in this region.
    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['NegotiationDate', 'PeriodStartDate', 'PeriodEndDate'];
        super.handleDataStateChange(state);
    }

    onCancelConsent() {
        this.isKeepExistingPeriods = true;
        this.getConsent.hide();
    }

    onConsent() {
        this.dataService.generateAllPeriods().subscribe(generatedPeriodsCount => {
            this.isKeepExistingPeriods = true;
            this.getConsent.hide();
            this.messageService.success(generatedPeriodsCount.toString() + this.translateService.instant('periods generated') + '.');
            this.refreshList();
        });
    }

    cloneRow(templatePeriod: EstateRentPeriod) {
        this.dataService.clonePeriod(templatePeriod.EstateRentPeriodId).subscribe(
            clonePeriodId => {
                this.messageService.success(this.translateService.instant(`Period cloned with ${clonePeriodId} id`) + '.');
                this.refreshList();
            }, error => {
                this.messageService.error(this.translateService.instant('Clone operation halted') + '!');
            }
        );
    }

    // sendMail(estateRentPeriod: EstateRentPeriod) {
    //     console.log('sendMail: ', estateRentPeriod);
    //     this.dataService.sendContractEndDateNotification(estateRentPeriod.EstateRentPeriodId).subscribe();
    // }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
