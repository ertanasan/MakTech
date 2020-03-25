// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { Loomis } from '@accounting/model/loomis.model';
import { LoomisService } from '@accounting/service/loomis.service';
import { LoomisEditComponent } from '@accounting/screen/loomis/loomis-edit/loomis-edit.component';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { HttpErrorResponse } from '@angular/common/http';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DatePipe } from '@angular/common';
import { process } from '@progress/kendo-data-query';
import * as _ from 'lodash';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import { ApproveMessageBoxComponent } from '@app-main/screen/approve-message-box/approve-message-box.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-loomis-list',
    templateUrl: './loomis-list.component.html',
    styleUrls: ['./loomis-list.component.css', ]
})
export class LoomisListComponent extends ListScreenBase<Loomis> implements AfterViewInit, OnInit {
    @ViewChild(LoomisEditComponent, {static: true}) editScreen: LoomisEditComponent;
    @ViewChild('approveConfirm', {static: true}) approveConfirm: CustomDialogComponent;
    @ViewChild('saleChangeApprove', {static: true}) saleChangeApprove: ApproveMessageBoxComponent;

    settings: Array<any> = [{text: 'Tümünü Aktar'}, {text: 'Seçilenleri Aktar'}, {text: 'Aktarımı Sil'}];
    checkedList =  [];
    selectedDay: Date = new Date(Date.now());
    loomisList: any;
    loomisActiveList: any;
    controlStatusList = [{value: 1, text: 'Tutarlı'},
        {value: 2, text: 'Beyan ile Sayılan Tutarlı'},
        {value: 3, text: 'Beyan ile Mutabakat Tutarlı'},
        {value: 4, text: 'Sayılan ile Mutabakat Tutarlı'},
        {value: 5, text: 'Tutarsız'}];
    localeDString: any;
    selectedRow: Loomis;
    approveMessage: string;
    approveTitle: string;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: LoomisService,
        public storeService: StoreService,
        public datePipe: DatePipe,
        public commonMethods: OverstoreCommonMethods,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        // this.listParams.take = 10;
        if (this.loomisList) {
            this.loomisActiveList = process(this.loomisList, this.listParams);
        }
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Accounting' }, {Caption: 'Loomis', RouterLink: '/accounting/loomis'}];
    }

    createEmptyModel(): Loomis {
        return new Loomis();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.storeService.completeList) {
            this.storeService.listAll();
        }
        super.ngOnInit();
    }

    ngAfterViewInit() {
        this.editScreen.mainScreen = this;
        this.dialogs.push(this.editScreen);
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    getDateList() {
        if (this.selectedDay) {
            const d = new Date(this.selectedDay);
            const selectedDayString = this.datePipe.transform(d, 'yyyy-MM-dd');
            this.dataService.loading = true;
            this.dataService.listDay(selectedDayString).subscribe(result => {
                this.loomisList = result;
                ((<Loomis[]>this.loomisList)).map(t => {
                    t.SaleDate = new Date(t.SaleDate);
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
        this.dataService.loadLoomisFile(formData).subscribe(result => {
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
        if (event.text === 'Aktarımı Sil') {
            this.dataService.CancelMikroTransfer(this.datePipe.transform(this.selectedDay, 'yyyy-MM-dd')).subscribe( result => {
                this.messageService.success(this.translateService.instant(`${this.selectedDay} tarihli Mikro aktarımı silindi.`));
                this.getDateList();
            }, (error: HttpErrorResponse) => {
                console.log(error);
                this.messageService.error(this.translateService.instant(`An error occured while transferring-${error.error}`));
            });
            return;
        }
        if (!this.loomisList) {
            this.messageService.warning('Aktarılacak kayıt bulunamadı.');
            return;
        }
        if (event.text === 'Tümünü Aktar') {
            this.checkedList = [];
            let recCount = 0;
            this.loomisList.forEach (row => {
                if (row.ControlCode !== 2 && row.MikroStatusCode === 0) {
                    recCount++;
                }
            });
            if (recCount === 0) {
                this.messageService.warning('Aktarılacak kayıt bulunamadı.');
                return;
            }
        } else {
            if (!this.checkedList || this.checkedList.length === 0) {
                this.messageService.warning('Aktarılacak kayıtları seçiniz');
                return;
            }
        }

        this.dataService.MikroTransfer(this.selectedDay, this.checkedList).subscribe(
            result => {
                this.messageService.success(this.translateService.instant(`Transferred to Mikro`));
                this.getDateList();
                this.checkedList = [];
            }, (error: HttpErrorResponse) => {
                console.log(error);
                this.messageService.error(this.translateService.instant(`An error occured while transferring-${error.error}`));
        });
    }

    handleDataStateChange(state: DataStateChangeEvent) {
        this.listParams.dateFields = ['BlockedDate', 'ValueDate'];
        super.handleDataStateChange(state);
    }

    onSelectedKeysChange(event) {

        event.forEach(rowno => {
            const selectedRow = _.filter(this.loomisList, ['LoomisId', rowno])[0];
            if (selectedRow && selectedRow.MikroStatusCode === 1) {
                this.messageService.warning('Bu kayıt Mikroya aktarılmış tekrar aktaramazsınız.');
                this.checkedList.pop();
            }
        });
    }

    onDeleteDay() {
        let transferredList = this.loomisList.filter(row => row.MikroStatusCode > 0);
        if (transferredList.length === 0) {
            this.localeDString = `${this.selectedDay.toLocaleDateString()} tarihli, dosyadan yapılan aktarımınız Maktech'den silinecektir.`;
            this.approveConfirm.caption = 'Approve';
            this.approveConfirm.show();
        } else {
            this.messageService.warning(`Mikro'ya aktarılmış kayıtlar var, önce Mikro aktarımını siliniz.`);
        }
    }

    public approveOnClicked() {
        this.dataService.ClearDate(this.datePipe.transform(this.selectedDay, 'yyyy-MM-dd')).subscribe( result => {
            this.messageService.success(this.translateService.instant(`${this.selectedDay} tarihli kayıtlar silindi.`));
            this.getDateList();
        }, (error: HttpErrorResponse) => {
            console.log(error);
            this.messageService.error(this.translateService.instant(`An error occured while transferring-${error.error}`));
        });
        this.approveConfirm.hide();
    }

    onSaleDateChange(event, dataItem:Loomis) {
        let selectedStore = this.storeService.completeList.filter(row => row.StoreId === dataItem.Store)[0];
        let d:Date = new Date(dataItem.SaleDate);
        d = this.commonMethods.addHours(d, 3);
        this.approveMessage = `${selectedStore.Name} mağazasının satış tarihi ${this.datePipe.transform(d, 'yyyy-MM-dd')} olarak değiştirilecektir, Onaylıyor musunuz`;
        this.approveTitle = `Satış Tarihi Değişimi Onay`;
        this.selectedRow = dataItem;
        this.saleChangeApprove.show();
    }

    onSaleChangeApproved() {
        let d:Date = new Date(this.selectedRow.SaleDate);
        d = this.commonMethods.addHours(d, 3);
        this.selectedRow.SaleDate = d;
        this.dataService.update(this.selectedRow).subscribe(result => {
            this.getDateList();
        }, error => {
            this.messageService.error(`Kaydedilemedi ${error.text}`);
        });

    }

    onSaleChangeCancelled() {
        this.getDateList();
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
