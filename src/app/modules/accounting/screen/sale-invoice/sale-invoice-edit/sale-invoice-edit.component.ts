// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input, Directive } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { SaleInvoice } from '@accounting/model/sale-invoice.model';
import { SaleInvoiceService } from '@accounting/service/sale-invoice.service';
import { Sales } from '@sale/model/sales.model';
import { SalesService } from '@sale/service/sales.service';
import { EInvoiceClient } from '@accounting/model/e-invoice-client.model';
import { EInvoiceClientService } from '@accounting/service/e-invoice-client.service';
import { SaleDetailService } from '@sale/service/sale-detail.service';
import { DatePipe } from '@angular/common';
import { KendoButtonService } from '@progress/kendo-angular-buttons/dist/es2015/button/button.service';
import { IdentityInfo } from '@accounting/model/identity-info.model';
import { CustomDialogComponent } from '@otuicontainer/dialog/custom-dialog/custom-dialog.component';

@Directive({
    selector: '[limit-to]',
    host: {
      '(keypress)': '_onKeypress($event)',
    }
  })
  export class LimitToDirective {
    @Input('limit-to') limitTo; 
    _onKeypress(e) {
       const limit = +this.limitTo;
       if (e.target.value.length === limit) e.preventDefault();
    }
  }
  
/*Section="ClassHeader"*/
@Component({
    selector: 'ot-sale-invoice-edit',
    templateUrl: './sale-invoice-edit.component.html',
    styleUrls: ['./sale-invoice-edit.component.css', ]
})
export class SaleInvoiceEditComponent extends CRUDDialogScreenBase<SaleInvoice> implements OnInit {
    @ViewChild(EditScreenContainerComponent, { static: true }) container: EditScreenContainerComponent<SaleInvoice>;
    @ViewChild(CustomDialogComponent, { static: false }) IdentityInfo: CustomDialogComponent;

    storeList: any;
    selectedStore: number;
    customerId: string;
    saleDetails: any;
    vknExists = false;
    invoice: SaleInvoice;
    captionBS = 'captionBS';
    captionWidth = 'md-3';
    editorBS = 'editorBS';
    editorWidth = 'md-9';
    eMailReadOnly = false;
    identityInfo: IdentityInfo;
    mask = "(999) 000-00-00";
    showIdentityInfo = false;
    isHeadQuarter: boolean;
    
    @Input() set SelectedStore(store) {
        this.selectedStore = store;
        this.onStoreSelected();
    }
    cancelSaleList: any;
    @Input() set CustomerId(id) {
        this.customerId = id;
        this.onCustomerIdChanged(1);
    }
    eInvoiceFlag = false;

    get statusCode() {
        return this.container.mainForm.get('StatusCode');
    }
    saleReadOnly = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: SaleInvoiceService,
        public salesService: SalesService,
        public saleDetailService: SaleDetailService,
        public eInvoiceClientService: EInvoiceClientService,
        public saleInvoiceService: SaleInvoiceService,
        public datePipe: DatePipe,
    ) {
        super(messageService, translateService, dataService, 'Sale Invoice');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            SaleInvoiceId: new FormControl(),
            Event: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            CreateChannel: new FormControl(),
            CreateBranch: new FormControl(),
            CreateScreen: new FormControl(),
            EInvoiceFlag: new FormControl(),
            CustomerIdNumber: new FormControl(),
            Title: new FormControl(),
            Email: new FormControl(),
            Sale: new FormControl(),
            EInvoiceClient: new FormControl(),
            Address: new FormControl(),
            Store: new FormControl(),
            PhoneNumber: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    onStoreSelected() {
        const saleId = this.container.mainForm.value.Sale;
        if (saleId && saleId > 0) {
            this.onSaleChanged(saleId);
        }
        if (this.container.actionName === 'Read') {
            this.salesService.read(saleId).subscribe(saleresult => {
                this.salesService.listCancelledSale(this.selectedStore, new Date(saleresult.TransactionDate), new Date(saleresult.TransactionDate)).subscribe(result => {
                    this.cancelSaleList = result;
                    this.cancelSaleList.forEach(row => {
                        const d: Date = new Date(row.TransactionDate);
                        const datestring: string = this.datePipe.transform(d, 'dd.MM.yyyy');
                        row.TransactionRef = datestring + ' - ' + row.Total.toString();
                    });
                });
            });
        } else {
            if (this.selectedStore) {
                const endDate: Date = new Date();
                const startDate = new Date();
                startDate.setDate(startDate.getDate() - 150);
                this.cancelSaleList = [];
                this.salesService.listCancelledSale(this.selectedStore, startDate, endDate).subscribe(result => {
                    this.cancelSaleList = result;
                    this.cancelSaleList.forEach(row => {
                        const d: Date = new Date(row.TransactionDate);
                        const datestring: string = this.datePipe.transform(d, 'dd.MM.yyyy');
                        row.TransactionRef = datestring + ' - ' + row.Total.toString() + (row.InvoiceId?' - Fatura Kesilmiş':'');
                    });
                });
            }
        }        
    }

    onCustomerIdChanged(event) {
        if (this.customerId && this.customerId.length < 10) {
            this.messageService.warning("Vergi kimlik numarası 10 rakamdan oluşmalıdır.");
            this.customerId = '';
            return;
        }
        if (this.customerId && this.customerId.toString().length > 7) {

            this.eInvoiceClientService.readIdentityInfo(this.customerId).subscribe(result => {
                this.identityInfo = result;
            });

            this.eInvoiceClientService.readEInvoice(this.customerId).subscribe(result => {
                if (result.EInvoiceClientId) {
                    this.container.mainForm.get('EInvoiceClient').setValue(result.EInvoiceClientId);
                    this.container.mainForm.get('EInvoiceFlag').setValue(true);
                    this.container.mainForm.get('Title').setValue(result.Title);
                    this.container.mainForm.get('Email').setValue(result.Alias);
                    this.eInvoiceFlag = true;
                    this.eMailReadOnly = false;
                } else {
                    this.eInvoiceClientService.readEInvoiceGIB(this.customerId).subscribe(result => {
                        if (result.EInvoiceClientId) {
                            this.container.mainForm.get('EInvoiceClient').setValue(result.EInvoiceClientId);
                            this.container.mainForm.get('EInvoiceFlag').setValue(true);
                            this.container.mainForm.get('Title').setValue(result.Title);
                            this.container.mainForm.get('Email').setValue(result.Alias);
                            this.eInvoiceFlag = true;
                            this.eMailReadOnly = false;
                        } else {
                            this.container.mainForm.get('EInvoiceFlag').setValue(false);
                            this.eInvoiceFlag = false;
                            this.eMailReadOnly = false;
                        }
                    });
                }
            });
            this.saleInvoiceService.CheckIfTaxIdentifierExists(this.customerId).subscribe(result => {
                this.vknExists = result;
            });
            
        }
    }

    onlyDigit(event) {
        if (event.charCode >= 48 && event.charCode <= 57) return true; else return false;
    }

    create() {
        if (this.cancelSaleList) {
            const selectedSale = this.cancelSaleList.filter(row => row.SalesId === this.currentItem.Sale)[0];
            if (selectedSale && selectedSale.InvoiceId && selectedSale.InvoiceId > 0) {
                this.messageService.warning('Bu fiş için önceden fatura kesilmiş, tekrar kesemezsiniz.');
                this.container.hideProgress();
                return;
            } else {
                this.currentItem.StatusCode = 0;
                this.currentItem.MikroFlag = false;
                this.currentItem.Organization = 1;
                this.currentItem.Event = 1;
                super.create();
            }
        } else {
            this.messageService.warning('iptal listesi gelmemiş');
        }
    }

    onSaleChanged(saleId) {
        if (saleId && saleId > 0) {
            this.saleDetailService.listSaleDetail(saleId).subscribe(result => {
                this.saleDetails = result;
            });
        }
    }

    review() {
        if (this.container.currentItem.actionChoice === 'Mikro') {
            if (this.vknExists) {
                super.review();
            } else {
                this.messageService.warning('Vergi numarası için Mikroda cari tanımı yapmanız gerekiyor.');
                this.container.hideProgress();
            }
        } else {
            super.review();
        }
    }

    onSelectedChange(event, period) {
        if (period === 1) {
            this.container.mainForm.get('EInvoiceFlag').setValue(true);
        } else {
            this.container.mainForm.get('EInvoiceFlag').setValue(false);
        }
    }

    onMikroCurrentAccount() {
        this.eInvoiceClientService.readIdentityInfo(this.customerId).subscribe(result => {
            this.identityInfo = result;
            this.showIdentityInfo = true;
            this.IdentityInfo.show();
        });
        
    }

    onClose() {
        this.IdentityInfo.hide();
    }

    onMikro() {
        if (this.identityInfo.IdentityName && this.identityInfo.IdentityName.length > 3) {
            this.identityInfo.EInvoiceFlag = this.eInvoiceFlag?1:0;
            this.identityInfo.Email = this.container.mainForm.value.Email;
            this.identityInfo.PhoneNumber = this.container.mainForm.value.PhoneNumber;
            this.saleInvoiceService.CreateCurrentAccount(this.identityInfo).subscribe(result => {
                this.messageService.success('Cari Hesap Oluşturuldu.');
                this.vknExists = true;
                this.IdentityInfo.hide();
            }, error => {
                this.messageService.error('Cari hesap oluşturulurken hata aldı.');
                console.log(error);
            });
        } else {
            this.messageService.warning('Kimlik Numarası ile bilgilere ulaşılamadı.');
        }
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
