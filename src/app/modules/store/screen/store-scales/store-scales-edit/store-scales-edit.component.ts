// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { FormControl } from '@angular/forms';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { StoreScales } from '@store/model/store-scales.model';
import { StoreScalesService } from '@store/service/store-scales.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';
import { ScaleModel } from '@store/model/scale-model.model';
import { ScaleModelService } from '@store/service/scale-model.service';
import { PackageVersion } from '@price/model/package-version.model';
import { PackageVersionService } from '@price/service/package-version.service';
import { TranslateService } from '@ngx-translate/core';
import { OverstoreCommonMethods } from 'app/util/common-methods.service';
import { finalize, first } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { OTContext } from '@otlib/auth/model/context.model';
import { Store as NgrxStore } from '@ngrx/store';
import * as fromApp from '@otlib/store/app.reducers';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-store-scales-edit',
    templateUrl: './store-scales-edit.component.html',
    styleUrls: ['./store-scales-edit.component.css', ]
})
export class StoreScalesEditComponent extends CRUDDialogScreenBase<StoreScales> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<StoreScales>;

    @Input() StoreId;
    public contextState$: Observable<OTContext>;
    isMomendeUser = false;

    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        dataService: StoreScalesService,
        public storeService: StoreService,
        public scaleModelService: ScaleModelService,
        public packageVersionService: PackageVersionService,
        public commonMethods: OverstoreCommonMethods,
        public scaleService: StoreScalesService,
        private store: NgrxStore<fromApp.AppState>,
    ) {
        super(messageService, translateService, dataService, 'Store Scales');
        this.contextState$ = this.store.select('context');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            StoreScalesId: new FormControl(),
            Organization: new FormControl(),
            Deleted: new FormControl(),
            CreateDate: new FormControl(),
            UpdateDate: new FormControl(),
            CreateUser: new FormControl(),
            UpdateUser: new FormControl(),
            Name: new FormControl(),
            Store: new FormControl(),
            ScaleModel: new FormControl(),
            PriceFilePath: new FormControl(),
            CurrentPriceVersion: new FormControl(),
            CurrentPriceLoadTime: new FormControl(),
            PrivatePriceVersion: new FormControl(),
            PrivatePriceLoadTime: new FormControl(),
            CreatePriceFileFlag: new FormControl(),
            IpAdress: new FormControl(),
            SerialNumber: new FormControl(),
            SealValidDate: new FormControl(),
        });
        this.container.mainForm.patchValue({Store: this.StoreId, CreatePriceFileFlag: false});
    }

    ngOnInit() {
        super.ngOnInit();
        this.contextState$.pipe(first()).subscribe(
            context => {
                this.isMomendeUser = context.Branch.Name === 'Momende';
            }
        );
    }

    /*Section="CustomCodeRegion"*/
    //#region Customized
    onSubmit() {
        if (this.container.currentItem.SealValidDate) {
            this.container.currentItem.SealValidDate = this.commonMethods.addHours(this.container.currentItem.SealValidDate, 3);
        }
        super.onSubmit();
    }

    create() {
        this.container.mainForm.patchValue({Store: this.StoreId, CreatePriceFileFlag: false});
        if (this.mainScreen.isEmbedded && this.isMomendeUser) {
            this.scaleService.createScale(this.currentItem).pipe(
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
            this.scaleService.updateScale(this.currentItem).pipe(
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
