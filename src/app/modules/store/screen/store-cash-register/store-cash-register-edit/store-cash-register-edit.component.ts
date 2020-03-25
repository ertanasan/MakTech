// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StoreCashRegister } from '@store/model/store-cash-register.model';
import { StoreCashRegisterService } from '@store/service/store-cash-register.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { CashRegisterModel } from '@store/model/cash-register-model.model';
import { CashRegisterModelService } from '@store/service/cash-register-model.service';
import { PackageVersion } from '@price/model/package-version.model';
import { PackageVersionService } from '@price/service/package-version.service';
import { finalize, first } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { OTContext } from '@otlib/auth/model/context.model';
import * as fromApp from '@otlib/store/app.reducers';
import { Store as NgrxStore } from '@ngrx/store';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-cash-register-edit',
    templateUrl: './store-cash-register-edit.component.html',
    styleUrls: ['./store-cash-register-edit.component.css', ]
})
export class StoreCashRegisterEditComponent extends CRUDDialogScreenBase<StoreCashRegister> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StoreCashRegister>;

    @Input() StoreId;
    public contextState$: Observable<OTContext>;
    isMomendeUser = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: StoreCashRegisterService,
        public storeService: StoreService,
        public cashRegisterModelService: CashRegisterModelService,
        public packageVersionService: PackageVersionService,
        public cashRegisterService: StoreCashRegisterService,
        private store: NgrxStore<fromApp.AppState>,
    ) {
        super(messageService,  translateService, dataService, 'Store Cash Register');
        this.hasAutomaticIdentity = false;
        this.contextState$ = this.store.select('context');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StoreCashRegisterId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Name: new FormControl(),
            Store: new FormControl(),
            CashRegisterModel: new FormControl(),
            PriceFilePath: new FormControl(),
            SaleFilePath1: new FormControl(),
            SaleFilePath2: new FormControl(),
            SaleFilePath3: new FormControl(),
            CurrentPriceVersion: new FormControl(),
            CurrentPriceLoadTime: new FormControl(),
            PrivatePriceVersion: new FormControl(),
            PrivatePriceLoadTime: new FormControl(),
            CreatePriceFileFlag: new FormControl(),
            IpAddress: new FormControl(),
            GibDeviceNo: new FormControl(),
            SerialNo: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
        this.contextState$.pipe(first()).subscribe(
            context => {
                this.isMomendeUser = context.Branch.Name === 'Momende';
            }
        )
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    create() {
        this.container.mainForm.patchValue({Store: this.StoreId, CreatePriceFileFlag: false});
        if (this.mainScreen.isEmbedded && this.isMomendeUser) {
            this.cashRegisterService.createCashRegister(this.currentItem).pipe(
                finalize(() => this.container.hideProgress())
            ).subscribe(
                model => {
                    this.messageService.success(this.translateService.instant(this.createSuccessMessage, {0: this.translateService.instant(this.modelName)}));
                    this.mainScreen.refreshData(this.currentItem.getId());
                    this.container.hide();
                },
                error => {
                    this.handleHttpError(error, this.createFailMessage, this.modelName);
                }
            );
        } else {
            super.create();
        }
    }

    update() {
        if (this.mainScreen.isEmbedded && this.isMomendeUser) {
            this.cashRegisterService.updateCashRegister(this.currentItem).pipe(
                finalize(() => this.container.hideProgress())
            ).subscribe(
                model => {
                    this.messageService.success(this.translateService.instant(this.updateSuccessMessage, {0: this.translateService.instant(this.modelName)}));
                    this.mainScreen.refreshData(this.currentItem.getId());
                    this.container.hide();
                },
                error => {
                    this.handleHttpError(error, this.updateFailMessage, this.modelName);
                }
            );
        } else {
            super.update();
        }
    }
    //#endregion Customized

    /*Section="ClassFooter"*/
}
