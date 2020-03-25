// Created by OverGenerator
/*Section="Imports"*/
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

import { CRUDDialogScreenBase } from '@otscreen-base/crud-dialog-screen-base';
import { GrowlMessageService } from '@otservice/growl-message.service';
import { OTUtilityService } from '@otcommon/service/utility.service';
import { EditScreenContainerComponent } from '@otuiscreen/edit-screen-container/edit-screen-container.component';

import { DaysOff } from '@reconciliation/model/days-off.model';
import { DaysOffService } from '@reconciliation/service/days-off.service';
import { Store } from '@store/model/store.model';
import { StoreService } from '@store/service/store.service';

/*Section="ClassHeader"*/
@Component({
    selector: 'ot-days-off-edit',
    templateUrl: './days-off-edit.component.html',
    styleUrls: ['./days-off-edit.component.css', ]
})
export class DaysOffEditComponent extends CRUDDialogScreenBase<DaysOff> implements OnInit {
    @ViewChild(EditScreenContainerComponent, {static: true}) container: EditScreenContainerComponent<DaysOff>;
    allStoresFlag = false;
    StoreList: number[] = [];
    storeListReadOnly = false;
    constructor(
        messageService: GrowlMessageService,
        translateService: TranslateService,
        public utilityService: OTUtilityService,
        dataService: DaysOffService,
        public storeService: StoreService,
    ) {
        super(messageService, translateService, dataService, 'Days Off');
    }

    createForm() {
        this.container.mainForm = this.container.formBuilder.group({
            DaysOffId: new FormControl(),
            Store: new FormControl(),
            OffDay: new FormControl(),
        });
    }

    ngOnInit() {
        super.ngOnInit();
    }

    create() {
        if (!this.currentItem.OffDay) {
            this.messageService.warning('Tarih giriniz');
            this.container.hideProgress();
            return;
        }
        if (this.allStoresFlag) {
            this.StoreList = this.storeService.completeList.filter(s => s.ActiveFlag === true).map(s => s.StoreId);
        }
        this.currentItem.OffDay = this.storeService.addHours(this.currentItem.OffDay, 3);

        const promiseArray = [];
        this.StoreList.forEach (sId => {
            this.currentItem.Store = sId;
            promiseArray.push(this.dataService.create(this.currentItem, 'Create').toPromise());
        });

        Promise.all(promiseArray).then(value => {
            this.messageService.success('Kaydedildi');
            this.mainScreen.refreshData(this.currentItem.getId());
            this.container.hide();
            this.container.hideProgress();
        }).catch(error => this.messageService.error('Beklenmeyen bir hata oluştu.'));
        // super.create();
    }

    onAllStoresChanged() {
        if (this.allStoresFlag) {
            this.StoreList = [];
            this.storeListReadOnly = true;
        } else {
            this.storeListReadOnly = false;
        }
    }
}
