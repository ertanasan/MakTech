// Created by OverGenerator
/*Section="Imports"*/
import { Component, ViewChild, OnInit, AfterViewInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

import { MenuItem } from '@otuicontrol/menu/menuitem';
import { ListScreenBase } from '@otscreen-base/list-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';

import { BankPosTransactions } from '@accounting/model/bank-pos-transactions.model';
import { BankPosTransactionsService } from '@accounting/service/bank-pos-transactions.service';
import { BankPosTransactionsEditComponent } from '@accounting/screen/bank-pos-transactions/bank-pos-transactions-edit/bank-pos-transactions-edit.component';
import { Bank } from '@store/model/bank.model';
import { BankService } from '@store/service/bank.service';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { DataStateChangeEvent } from '@progress/kendo-angular-grid';
import { DatePipe } from '@angular/common';
import { process } from '@progress/kendo-data-query';
import * as _ from 'lodash';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-bank-pos-transactions-list',
    templateUrl: './bank-pos-transactions-list.component.html',
    styleUrls: ['./bank-pos-transactions-list.component.css', ]
})
export class BankPosTransactionsListComponent extends ListScreenBase<BankPosTransactions> implements AfterViewInit, OnInit {
    @ViewChild(BankPosTransactionsEditComponent, {static: true}) editScreen: BankPosTransactionsEditComponent;
    @ViewChild('approveConfirm', {static: true}) approveConfirm: CustomDialogComponent;

    settings: Array<any> = [{text: 'Tümünü Aktar'}, {text: 'Seçilenleri Aktar'}, {text: 'Aktarımı Sil'}];
    checkedList =  [];
    selectedDay: Date = new Date(Date.now());
    posList: any;
    posActiveList: any;
    controlStatusList = [{value: 1, text: 'Tutarlı'}, {value: 2, text: 'Mağaza tanımsız'}, {value: 3, text: 'Mağaza toplamı tutarsız'}];
    selectedBank: any;
    localeDString: string;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        public dataService: BankPosTransactionsService,
        public bankService: BankService,
        public datePipe: DatePipe,
    ) {
        super(messageService, translateService);
    }

    refreshList() {
        // this.listParams.pageable = false;
        // this.listParams.take = 10;
        if (this.posList) {
            this.posActiveList = process(this.posList, this.listParams);
        }
        // this.dataService.list(this.listParams);
    }

    getBreadcrumbItems(): MenuItem[] {
        return [{Caption: 'Accounting' }, {Caption: 'Bank Pos Transactions', RouterLink: '/accounting/bank-pos-transactions'}];
    }

    createEmptyModel(): BankPosTransactions {
        return new BankPosTransactions();
    }

    ngOnInit() {
        // Fill reference lists
        if (!this.bankService.completeList) {
            this.bankService.listAll();
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
                this.posList = result;
                ((<BankPosTransactions[]>this.posList)).map(t => {
                    t.BlockedDate = new Date(t.BlockedDate);
                    if (t.ValueDate) {
                        t.ValueDate = new Date(t.ValueDate);
                    }
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
        // console.log(this.selectedBank);
        if (this.selectedBank.BankId === 1) {
            this.dataService.loadBankPOSFile(formData).subscribe(result => {
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
                this.messageService.error(error.error.text);
                event.target.value = '';
            });
        } else if (this.selectedBank.BankId === 4) {
            this.dataService.ziraatLoadBankPOSFile(formData).subscribe(result => {
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
                this.messageService.error(error.error.text);
                event.target.value = '';
            });
        } else {
            this.messageService.warning("Tanımsız Banka");
            this.dataService.loading = false;
        }
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
        if (!this.posList) {
            this.messageService.warning('Aktarılacak kayıt bulunamadı.');
            return;
        }
        if (event.text === 'Tümünü Aktar') {
            this.checkedList = [];
            let recCount = 0;
            this.posList.forEach (row => {
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
            const selectedRow = _.filter(this.posList, ['BankPosTransactionsId', rowno])[0];
            if (selectedRow && selectedRow.MikroStatusCode === 1) {
                this.messageService.warning('Bu kayıt Mikroya aktarılmış tekrar aktaramazsınız.');
                this.checkedList.pop();
            }
        });
    }

    onDeleteDay() {
        this.localeDString = `${this.selectedDay.toLocaleDateString()} tarihli, dosyadan yapılan aktarımınız Maktech'den silinecektir.`;
        this.approveConfirm.caption = 'Approve';
        this.approveConfirm.show();      
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
    //#endregion Customized

    /*Section="ClassFooter"*/
}
